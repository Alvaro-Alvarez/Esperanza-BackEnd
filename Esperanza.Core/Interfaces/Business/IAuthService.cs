using Esperanza.Core.Models;

namespace Esperanza.Core.Interfaces.Business
{
    public interface IAuthService
    {
        Task<AppUser> ValidateUser(LoginCredentials credentials);
    }
}
