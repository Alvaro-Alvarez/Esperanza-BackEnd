using Esperanza.Core.Models;

namespace Esperanza.Core.Interfaces.DataAccess
{
    public interface IPromotionalVideoRepository : IGenericRepository<PromotionalVideo>
    {
        Task<List<PromotionalVideo>> GetAll();
        Task<PromotionalVideo> GetById(string id);
        Task<List<PromotionalVideo>> GetTopFive();
    }
}
