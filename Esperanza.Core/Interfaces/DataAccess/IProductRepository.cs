using Esperanza.Core.Models;
using Esperanza.Core.Models.Request;
using Esperanza.Core.Models.Response;

namespace Esperanza.Core.Interfaces.DataAccess
{
    public interface IProductRepository : IGenericRepository<Product>
    {
        Task<List<ProductsSyncResponseDTO>> GetTopFive(bool logged, string clitenCode);
        Task<List<ProductsSyncResponseDTO>> GetAllPaginatedNew(Filter filter, bool logged, string clientCode);
        Task<List<ProductsSyncResponseDTO>> GetAllByLaboratory(GetByLaboratory filter, bool logged, string clitenCode);
        Task<ProductsSyncResponseDTO> GetById(string cod, string clientCode);
        Task<ProductsSyncResponseDTO> GetByIdNologged(string cod);
        Task<List<ProductsSyncResponseDTO>> GetAllPaginated(Filter filter, string clientCode);
        Task<int> GetCount(string clientCode, Filter filter);
        Task<List<ProductsSyncResponseDTO>> GetAllNoLoggedPaginated(Filter filter);
        Task<int> GetNoLoggedCount(Filter filter);
        Task<ValuesToFilter> GetValuesToFilter(Filter filter, string clientCode);
        Task<ValuesToFilter> GetValuesToFilterNoLogged(Filter filter);
        Task<ValuesToFilter> GetValuesToFilterNew(Filter filter, bool logged, string clientCode);
        Task<List<ProductsSyncDTO>> GetAlllNoLogged(Filter filter);
        Task<List<ProductsSyncDTO>> GetAlll(Filter filter, string clientCode);
        Task<List<ProductsSyncResponseDTO>> GetProductsWithUpdatePrices(List<ProductsSyncDTO> products, bool noLogged = false);
        Task<ValuesToFilter> FillValuesToFilter(List<ProductsSyncDTO> products);
        Task<List<ProductsSyncDTO>> GetAllRecommended(GetRecommended request);
        Task<List<string>> GetImagesByCodes(GetRecommended request);
    }
}
