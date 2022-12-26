using Esperanza.Core.Models;
using Esperanza.Core.Models.Request;

namespace Esperanza.Core.Interfaces.DataAccess
{
    public interface IProductRepository : IGenericRepository<Product>
    {
        Task<List<Product>> GetAllFull();
        Task<Product> GetById(string guid);
        Task<List<Product>> GetAllPaginated(Pagination pagination);
        Task<List<Product>> GetAllLight();
        Task<int> GetCount();
    }
}
