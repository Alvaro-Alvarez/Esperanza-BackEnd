namespace Esperanza.Core.Models.Request
{
    public class ResetPassword
    {
        public string? Email { get; set; }
        public string? ReCaptchaToken { get; set; }
    }

    public class ConfirmResetPassword
    {
        public string? Email { get; set; }
        public string? VerificationCode { get; set; }
        public string? NewPassword { get; set; }
    }

    public class ResetPasswordResponse
    {
        public string? Email { get; set; }
    }
}
