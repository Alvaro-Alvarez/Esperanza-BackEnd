using Esperanza.Core.Models;
using Esperanza.Core.Models.Request;

namespace Esperanza.Core.Interfaces.Business
{
    public interface IAuthService
    {
        Task<AppUser> ValidateUser(LoginCredentials credentials);
        Task ResetPassword(ResetPassword request);
        //Task<ResetPasswordResponse> ResetPassword(ResetPassword request);
        Task ConfirmResetPassword(ConfirmResetPassword request);
    }
}
