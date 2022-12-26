using Esperanza.Core.Models;

namespace Esperanza.Core.Interfaces.DataAccess
{
    public interface ILineRepository : IGenericRepository<Line>
    {
        Task InsertManyToMany(List<Guid> guids, Guid productGuid);
        Task<List<Line>> GetAllByProductId(string productGuid);
    }
}
