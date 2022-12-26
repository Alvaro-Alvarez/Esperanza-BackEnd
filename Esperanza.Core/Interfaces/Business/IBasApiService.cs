using Esperanza.Core.Models.Response;

namespace Esperanza.Core.Interfaces.Business
{
    public interface IBasApiService
    {
        Task<bool> CustomerExists(string clientId);
        Task<ClientResponse> GetClientBas(string clientId);
        Task<ProductResponse> GetProductCCMBas(string clientCode, string productCode);
        Task<ProductResponse> GetProductCCBBas(string clientCode, string productCode);
    }
}
