using Esperanza.Core.Models;

namespace Esperanza.Core.Interfaces.Business
{
    public interface ILaboratoryService
    {
        Task<List<Laboratory>> GetAll();
        Task<List<Laboratory>> GetTopFive();
        Task<Laboratory> GetById(string id);
        Task<Laboratory> Insert(Laboratory laboratory, string userId);
        Task<Laboratory> Update(Laboratory laboratory, string userId);
        Task Delete(string id, string userId);
    }
}
