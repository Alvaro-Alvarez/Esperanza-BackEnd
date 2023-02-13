using Esperanza.Core.Models;
using Esperanza.Core.Models.Request;
using Esperanza.Core.Models.SPs;

namespace Esperanza.Core.Interfaces.Business
{
    public interface IPromotionalVideoService
    {
        Task<List<PromotionalVideo>> GetAll();
        Task<List<PromotionalVideo>> GetTopFive();
        Task<List<VideoSp>> GetAllWithPagination(Pagination pagination);
        Task<PromotionalVideo> GetById(string id);
        Task<PromotionalVideo> Insert(PromotionalVideo promotionalVideo, string userId);
        Task<PromotionalVideo> Update(PromotionalVideo promotionalVideo, string userId);
        Task Delete(string id, string userId);
    }
}
