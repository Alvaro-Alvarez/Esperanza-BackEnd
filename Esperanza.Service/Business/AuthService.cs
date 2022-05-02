using Esperanza.Core.Interfaces.Business;
using Esperanza.Core.Interfaces.DataAccess;
using Esperanza.Core.Models;
using System.Security.Authentication;

namespace Esperanza.Service.Business
{
    public class AuthService : IAuthService
    {
        private readonly IAppUserRepository UserRepository;
        private readonly IReCaptcharService ReCaptcharService;

        public AuthService(IAppUserRepository userRepository, IReCaptcharService reCaptcharService)
        {
            UserRepository = userRepository;
            ReCaptcharService = reCaptcharService;
        }

        public async Task<AppUser> ValidateUser(LoginCredentials credentials)
        {
            try
            {
                AppUser user = await UserRepository.GetUserByEmailAsync(credentials.Username);
                if (user != null)
                {
                    bool captcha = await ReCaptcharService.Validate(credentials.ReCaptchaToken);
                    if (captcha) return user;
                    else throw new Exception("ReCaptcha inválido");
                }
                else throw new AuthenticationException("Este usuario no existe.");
            }
            catch (Exception e)
            {
                throw e;
            }
        }
    }
}
