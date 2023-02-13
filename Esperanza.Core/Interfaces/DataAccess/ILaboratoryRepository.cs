using Esperanza.Core.Models;
using Esperanza.Core.Models.Request;
using Esperanza.Core.Models.SPs;

namespace Esperanza.Core.Interfaces.DataAccess
{
    public interface ILaboratoryRepository : IGenericRepository<Laboratory>
    {
        Task<List<Laboratory>> GetAll();
        Task<Laboratory> GetById(string id);
        Task<List<Laboratory>> GetTopFive();
        Task<List<LaboratorySp>> GetAllSp(Pagination pagination);
    }
}
