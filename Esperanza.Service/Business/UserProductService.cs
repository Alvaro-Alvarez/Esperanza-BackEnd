using Esperanza.Core.Constants;
using Esperanza.Core.Interfaces.Business;
using Esperanza.Core.Interfaces.DataAccess;
using Esperanza.Core.Models;
using Esperanza.Core.Models.Response;
using Esperanza.Service.Helpers;

namespace Esperanza.Service.Business
{
    public class UserProductService : IUserProductService
    {
        //private readonly IBasApiService _basApiService;
        //private readonly IProductService _productService;
        //private readonly IAppUserRepository _userRepository;
        //private readonly IUserProductRepository _userProductRepository;

        //public UserProductService(
        //    IBasApiService basApiService,
        //    IProductService productService,
        //    IAppUserRepository userRepository,
        //    IUserProductRepository userProductRepository)
        //{
        //    _basApiService = basApiService;
        //    _userRepository = userRepository;
        //    _userProductRepository = userProductRepository;
        //    _productService = productService;
        //}

        //public async Task UpdatePrices()
        //{
        //    //var users = await _userRepository.GetAllAsync();
        //    //users = users.Where(x => x.RoleGuid.ToString().ToLower() == RoleConstant.Client.ToLower()).ToList();
        //    //foreach (var user in users)
        //    //{
        //    //    await UpdatePrices(user.Guid.ToString(), user);
        //    //}
        //}

        //public async Task UpdatePrices(string userGuid, AppUser user = null)
        //{
        //    if (user == null) user = await _userRepository.GetAsync(userGuid);
        //    var userProducts = await _userProductRepository.GetAllByUser(userGuid);
        //    var products = await _productService.GetAllLight();
        //    var clientBas = await _basApiService.GetClientBas(user.BasClientCode);
        //    if (clientBas != null)
        //    {
        //        if (userProducts.Count == 0)
        //        {
        //            await InsertUserProducts(products, clientBas, userGuid);
        //        }
        //        else
        //        {
        //            var productsToInsert = products.Where(p => !userProducts.Select(x => x.Guid).Contains(p.Guid)).ToList();
        //            await UpdateUserProducts(products, userProducts, clientBas, userGuid);
        //            await InsertUserProducts(productsToInsert, clientBas, userGuid);
        //        }
        //    }
        //}

        //private async Task InsertUserProducts(List<Product> products, ClientResponse clientBas, string userGuid)
        //{
        //    List<UserProduct> userProducts = new();
        //    foreach (var product in products)
        //    {
        //        var userProduct = new UserProduct();
        //        decimal productPrice = await GetProductPrice(clientBas, product.BasProductCode);
        //        EntityHelper.InitEntity(userProduct, new Guid(userGuid));
        //        userProduct.UserGuid = new Guid(userGuid);
        //        userProduct.ProductGuid = product.Guid;
        //        userProduct.ProductPrice = productPrice;
        //        userProducts.Add(userProduct);
        //    }
        //    if (userProducts.Count > 0)
        //        await _userProductRepository.SaveRangeAsync(userProducts);
        //}

        //private async Task UpdateUserProducts(List<Product> products, List<UserProduct> userProducts, ClientResponse clientBas, string userGuid)
        //{
        //    foreach (var userProduct in userProducts)
        //    {
        //        EntityHelper.ModifyEntity(userProduct, new Guid(userGuid));
        //        decimal productPrice = await GetProductPrice(clientBas, products.Where(x => x.Guid == userProduct.Guid).FirstOrDefault().BasProductCode);
        //        userProduct.ProductPrice = productPrice;
        //        await _userProductRepository.UpdateAsync(userProduct);
        //    }
        //}

        //private async Task<decimal> GetProductPrice(ClientResponse clientBas, string basProductCode)
        //{
        //    ProductResponse productCCM = new ProductResponse();
        //    ProductResponse productCCB = new ProductResponse();
        //    if (clientBas.CondicionVentaMedicamentos.Equals("CCM"))
        //        productCCM = await _basApiService.GetProductCCMBas(clientBas.Codigo, basProductCode);
        //    if (clientBas.CondicionVentaBalanceado.Equals("CCB"))
        //        productCCB = await _basApiService.GetProductCCBBas(clientBas.Codigo, basProductCode);
        //    decimal CCMPrice = !string.IsNullOrEmpty(productCCM.Codigo) ? Convert.ToDecimal(productCCM.Precio) : 0;
        //    decimal CCBPrice = !string.IsNullOrEmpty(productCCB.Codigo) ? Convert.ToDecimal(productCCB.Precio) : 0;
        //    return new List<decimal>() { CCMPrice, CCBPrice }.Max();
        //}
    }
}
