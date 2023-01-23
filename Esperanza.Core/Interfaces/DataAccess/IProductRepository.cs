using Esperanza.Core.Models;
using Esperanza.Core.Models.Request;
using Esperanza.Core.Models.Response;

namespace Esperanza.Core.Interfaces.DataAccess
{
    public interface IProductRepository : IGenericRepository<Product>
    {
        Task<List<Product>> GetAllFull();
        Task<ProductsSyncResponseDTO> GetById(string cod);
        Task<ProductsSyncResponseDTO> GetByIdNologged(string cod);
        Task<List<ProductsSyncResponseDTO>> GetAllPaginated(Pagination pagination, string clientCode);
        Task<List<Product>> GetAllLight();
        Task<int> GetCount(string clientCode);
        Task<List<ProductsSyncResponseDTO>> GetAllNoLoggedPaginated(Pagination pagination);
        Task<int> GetNoLoggedCount();
    }
}
