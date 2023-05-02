using Esperanza.Core.Interfaces.Business;
using Esperanza.Core.Interfaces.DataAccess;
using Esperanza.Core.Models;
using Esperanza.Core.Models.Options;
using Esperanza.Core.Models.Request;
using Esperanza.Core.Models.Response;
using Microsoft.Extensions.Options;
using RestSharp;

namespace Esperanza.Service.Business
{
    public class ProductService : IProductService
    {
        private readonly IAppUserRepository UserRepository;
        private readonly IProductRepository ProductRepository;
        private readonly ServicesOption _servicesOption;

        public ProductService(
                    IAppUserRepository userRepository,
                    IProductRepository productRepository,
                    IOptions<ServicesOption> servicesOption
                    )
        {
            UserRepository = userRepository;
            ProductRepository = productRepository;
            _servicesOption = servicesOption.Value;
        }

        public async Task<ProductsResponse> GetAllByLaboratory(GetByLaboratory filter, string userGuid, bool logged)
        {
            var user = new AppUser();
            if (logged) user = await UserRepository.GetAsync(userGuid);
            var products = await ProductRepository.GetAllByLaboratory(filter, logged, logged ? user.BasClientCode : null);
            var rows = products.Count > 0 ? products.FirstOrDefault().ROW_COUNT : 0;
            return new ProductsResponse()
            {
                Products = products,
                ValuesToFilter = null,
                Rows = rows
            };
        }

        public async Task<ProductsResponse> GetTopFive(string userGuid, bool logged)
        {
            var user = new AppUser();
            if (logged) user = await UserRepository.GetAsync(userGuid);
            var products = await ProductRepository.GetTopFive(logged, logged ? user.BasClientCode : null);
            var rows = 0;
            return new ProductsResponse()
            {
                Products = products,
                ValuesToFilter = null,
                Rows = rows
            };
        }

        public async Task<ProductsResponse> GetAllRecommended(GetRecommended request, string userGuid)
        {
            request.ProductCodes = request.ProductCodes.Distinct().ToList();
            var user = string.IsNullOrEmpty(userGuid) ? null : await UserRepository.GetAsync(userGuid);
            var products = await ProductRepository.GetAllRecommended(request, user != null ? user.BasClientCode : "001");
            var cleanProducts = await ProductRepository.GetProductsWithUpdatePrices(products, false);
            await FillSemaphore(cleanProducts);
            var rows = products.Count();
            return new ProductsResponse()
            {
                Products = cleanProducts,
                ValuesToFilter = null,
                Rows = rows
            };
        }

        public async Task<ProductsResponse> GetByVademecumFilter(VademecumFilter filter, string userGuid)
        {
            var user = string.IsNullOrEmpty(userGuid) ? null : await UserRepository.GetAsync(userGuid);
            var products = await ProductRepository.GetByVademecumFilter(filter, user != null ? user.BasClientCode : "001");
            var cleanProducts = await ProductRepository.GetProductsWithUpdatePrices(products, false);
            await FillSemaphore(cleanProducts);
            var rows = products.FirstOrDefault()?.ROW_COUNT;
            return new ProductsResponse()
            {
                Products = cleanProducts,
                ValuesToFilter = null,
                Rows = rows.HasValue ? rows.Value : 0
            };
        }

        public async Task<List<string>> GetImagesByCodes(GetRecommended request)
        {
            return await ProductRepository.GetImagesByCodes(request);
        }
        
        public async Task<ProductsResponse> GetAllPaginated(Filter filter, string userGuid, bool logged)
        {
            List<ProductsSyncDTO>? products;
            var user = new AppUser();
            if (logged) user = await UserRepository.GetAsync(userGuid);
            if (logged) products = await ProductRepository.GetAlll(filter, user.BasClientCode);
            else products = await ProductRepository.GetAlllNoLogged(filter);
            var rows = products.Count();
            var init = filter.Start.HasValue ? filter.Start.Value : 0;
            var count = (products.Count() - 10) >= 10 ? 10 : products.Count();
            //var init = filter.Start.HasValue ? filter.Start.Value : 0;
            //var finish = (products.Count()-10) >= 10 ? 10 : products.Count();
            var paginationProducts = products.GetRange(init, count);
            var cleanProducts = await ProductRepository.GetProductsWithUpdatePrices(paginationProducts, !logged);
            var valsToFilter = await ProductRepository.FillValuesToFilter(products);
            if (filter.WithSemaphore.HasValue && filter.WithSemaphore.Value) await FillSemaphore(cleanProducts);
            return new ProductsResponse()
            {
                Products = cleanProducts,
                ValuesToFilter = valsToFilter,
                Rows = rows
            };
        }

        public async Task<ProductsSyncResponseDTO> GetById(string cod, bool logged, string userGuid)
        {
            var product = new ProductsSyncResponseDTO();
            var user = new AppUser();
            if (logged) user = await UserRepository.GetAsync(userGuid);
            if (logged) product = await ProductRepository.GetById(cod, user.BasClientCode);
            else product = await ProductRepository.GetByIdNologged(cod);
            return product;
        }

        #region Private Methods
        private async Task FillSemaphore(List<ProductsSyncResponseDTO> products)
        {
            await Parallel.ForEachAsync(products, async (product, cancellationToken) =>
            {
                var client = new RestClient(_servicesOption.Url);
                var request = new RestRequest($"{_servicesOption.SemaphoreController}{product.CODIGO}", Method.Get);
                var res = await client.ExecuteAsync(request);
                product.Semaphore = res.Content;
            });
        }
        #endregion
    }
}
