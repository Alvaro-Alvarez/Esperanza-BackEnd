using Esperanza.Core.Models;

namespace Esperanza.Core.Interfaces.DataAccess
{
    public interface IProductRepository : IGenericRepository<Product>
    {
        Task<List<Product>> GetAllFull();
        Task<Product> GetById(string guid);
    }
}
