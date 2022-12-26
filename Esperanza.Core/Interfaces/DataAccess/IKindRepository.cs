using Esperanza.Core.Models;

namespace Esperanza.Core.Interfaces.DataAccess
{
    public interface IKindRepository : IGenericRepository<Kind>
    {
        Task InsertManyToMany(List<Guid> guids, Guid productGuid);
        Task<List<Kind>> GetAllByProductId(string productGuid);
    }
}
