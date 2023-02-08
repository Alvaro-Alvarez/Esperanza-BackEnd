using Esperanza.Core.Models;

namespace Esperanza.Core.Interfaces.Business
{
    public interface IPromotionalVideoService
    {
        Task<List<PromotionalVideo>> GetAll();
        Task<List<PromotionalVideo>> GetTopFive();
        Task<PromotionalVideo> GetById(string id);
        Task<PromotionalVideo> Insert(PromotionalVideo promotionalVideo, string userId);
        Task<PromotionalVideo> Update(PromotionalVideo promotionalVideo, string userId);
        Task Delete(string id, string userId);
    }
}
