using Esperanza.Core.Models;

namespace Esperanza.Core.Interfaces.DataAccess
{
    public interface IAppUserRepository : IGenericRepository<AppUser>
    {
        Task<AppUser> GetUserAsync(Guid userGuid);
        Task<AppUser> GetUserByEmailAsync(string email);
    }
}
