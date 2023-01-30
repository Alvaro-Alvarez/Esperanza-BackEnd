using Esperanza.Core.Models;
using Esperanza.Core.Models.Request;
using Esperanza.Core.Models.Response;

namespace Esperanza.Core.Interfaces.DataAccess
{
    public interface IProductRepository : IGenericRepository<Product>
    {
        Task<ProductsSyncResponseDTO> GetById(string cod, string clientCode);
        Task<ProductsSyncResponseDTO> GetByIdNologged(string cod);
        Task<List<ProductsSyncResponseDTO>> GetAllPaginated(Filter filter, string clientCode);
        Task<int> GetCount(string clientCode, Filter filter);
        Task<List<ProductsSyncResponseDTO>> GetAllNoLoggedPaginated(Filter filter);
        Task<int> GetNoLoggedCount(Filter filter);
        Task<ValuesToFilter> GetValuesToFilter(Filter filter, string clientCode);
        Task<ValuesToFilter> GetValuesToFilterNoLogged(Filter filter);
    }
}
