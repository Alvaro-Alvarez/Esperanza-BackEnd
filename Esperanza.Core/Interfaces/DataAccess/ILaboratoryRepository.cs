using Esperanza.Core.Models;

namespace Esperanza.Core.Interfaces.DataAccess
{
    public interface ILaboratoryRepository : IGenericRepository<Laboratory>
    {
        Task<List<Laboratory>> GetAll();
        Task<Laboratory> GetById(string id);
        Task<List<Laboratory>> GetTopFive();
    }
}
