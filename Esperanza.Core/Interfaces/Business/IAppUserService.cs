using Esperanza.Core.Models;

namespace Esperanza.Core.Interfaces.Business
{
    public interface IAppUserService
    {
        Task<List<AppUser>> GetAllAsync();
        Task<AppUser> GetByGuidAsync(string userGuid);
        Task InsertAsync(AppUser user, string userGuid);
        Task UpdateAsync(AppUser user, string userName);
        Task DeleteAsync(string guid, string userName);
    }
}
