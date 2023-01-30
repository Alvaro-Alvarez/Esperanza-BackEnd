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

        public async Task<ProductsResponse> GetAllPaginated(Filter filter, string userGuid, bool logged)
        {
            var products = new List<ProductsSyncResponseDTO>();
            var user = new AppUser();
            if (logged) user = await UserRepository.GetAsync(userGuid);
            if (logged) products = await ProductRepository.GetAllPaginated(filter, user.BasClientCode);
            else products = await ProductRepository.GetAllNoLoggedPaginated(filter);
            if (filter.WithSemaphore.HasValue && filter.WithSemaphore.Value) await FillSemaphore(products);
            return new ProductsResponse()
            {
                Products = products,
                ValuesToFilter = logged ? await ProductRepository.GetValuesToFilter(filter, user.BasClientCode) : await ProductRepository.GetValuesToFilterNoLogged(filter),
                Rows = logged ? await ProductRepository.GetCount(user.BasClientCode, filter) : await ProductRepository.GetNoLoggedCount(filter)
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
