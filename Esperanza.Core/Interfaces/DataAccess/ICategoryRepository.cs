using Esperanza.Core.Models;

namespace Esperanza.Core.Interfaces.DataAccess
{
    public interface ICategoryRepository : IGenericRepository<Category>
    {
        Task InsertManyToMany(List<Guid> guids, Guid productGuid);
        Task<List<Category>> GetAllByProductId(string productGuid);
    }
}
