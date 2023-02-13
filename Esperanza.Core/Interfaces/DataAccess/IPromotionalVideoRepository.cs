using Esperanza.Core.Models;
using Esperanza.Core.Models.Request;
using Esperanza.Core.Models.SPs;

namespace Esperanza.Core.Interfaces.DataAccess
{
    public interface IPromotionalVideoRepository : IGenericRepository<PromotionalVideo>
    {
        Task<List<PromotionalVideo>> GetAll();
        Task<PromotionalVideo> GetById(string id);
        Task<List<PromotionalVideo>> GetTopFive();
        Task<List<VideoSp>> GetAllSp(Pagination pagination);
    }
}
