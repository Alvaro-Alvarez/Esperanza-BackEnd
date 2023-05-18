using Esperanza.Core.Models;

namespace Esperanza.Core.Interfaces.DataAccess
{
    public interface IAppUserRepository : IGenericRepository<AppUser>
    {
        Task<AppUser> GetUserAsync(Guid userGuid);
        Task<AppUser> GetUserByEmailAsync(string email);
        Task<List<AppUser>> GetAllFull();
        Task<bool> Exist(string email, string clientCode);
        Task UpdateCodeVerification(string code, string email);
    }
}
