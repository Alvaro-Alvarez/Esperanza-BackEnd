using Esperanza.Core.Constants;
using Esperanza.Core.Exceptions;
using Esperanza.Core.Helpers;
using Esperanza.Core.Interfaces.Business;
using Esperanza.Core.Interfaces.DataAccess;
using Esperanza.Core.Models;
using Esperanza.Core.Models.Request;

namespace Esperanza.Service.Business
{
    public class AuthService : IAuthService
    {
        private readonly IAppUserRepository UserRepository;
        private readonly IReCaptcharService ReCaptcharService;
        private readonly IEmailService EmailService;

        public AuthService(IAppUserRepository userRepository, IReCaptcharService reCaptcharService, IEmailService emailService)
        {
            UserRepository = userRepository;
            ReCaptcharService = reCaptcharService;
            EmailService = emailService;
        }

        public async Task<AppUser> ValidateUser(LoginCredentials credentials)
        {
            try
            {
                AppUser user = await UserRepository.GetUserByEmailAsync(credentials.Username);
                if (user != null)
                {
                    bool captcha = await ReCaptcharService.Validate(credentials.ReCaptchaToken);
                    if (captcha)
                    {
                        if (user.Pass != HashHelper.HashPassword(user.Guid.ToString(), credentials.Password))
                            throw new BusinessException(Core.Enums.ErrorCode.InvalidPassword);
                        return user;
                    }
                    else throw new BusinessException(Core.Enums.ErrorCode.InvalidReCaptcha);
                }
                else throw new BusinessException(Core.Enums.ErrorCode.UserNotFound);
            }
            catch (Exception e)
            {
                throw e;
            }
        }

        public async Task ResetPassword(ResetPassword request)
        {
            AppUser user = await UserRepository.GetUserByEmailAsync(request.Email);
            if (user == null) throw new BusinessException(Core.Enums.ErrorCode.UserNotFound);
            bool captcha = await ReCaptcharService.Validate(request.ReCaptchaToken);
            if (!captcha) throw new BusinessException(Core.Enums.ErrorCode.InvalidReCaptcha);
            var newCode = CodeHelper.RandomString(length: 5, onlyNumber: true);
            await EmailService.SendMail(
                emailType: EmailTypeConstant.VerificationCodeChangePassword,
                values: new Dictionary<string, string>
                {
                    { "Code", newCode },
                    { "Email", request.Email }
                },
                tos: new List<string>() { request.Email });
            await UserRepository.UpdateCodeVerification(newCode, request.Email);
        }

        public async Task ConfirmResetPassword(ConfirmResetPassword request)
        {
            AppUser user = await UserRepository.GetUserByEmailAsync(request.Email);
            if (request.VerificationCode != user.VerificationCode) throw new BusinessException(Core.Enums.ErrorCode.InvalidCodeRecovery);
            user.Pass = HashHelper.HashPassword(user.Guid.ToString(), request.NewPassword);
            user.VerificationCode = null;
            user.UpdatedAt = DateTime.UtcNow;
            await UserRepository.UpdateAsync(user);
        }
    }
}
