using Esperanza.Core.Models;

namespace Esperanza.Core.Interfaces.Business
{
    public interface IProductService
    {
        Task<List<Product>> GetAllFull();
        Task<Product> GetById(string guid);
        Task<Product> InsertProduct(Product product, string userGuid);
        Task<Product> UpdateProduct(Product product, string userGuid);
        Task DeleteProduct(string guid, string userGuid);
    }
}
