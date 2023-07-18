using System.ComponentModel;

namespace Esperanza.Core.Enums
{
    public enum ErrorCode
    {
        [Description("UserNotFound")]
        UserNotFound = 1,
        [Description("InvalidPassword")]
        InvalidPassword = 2,
        [Description("InvalidReCaptcha")]
        InvalidReCaptcha = 3,
        [Description("UserFound")]
        UserFound = 4,
        [Description("InvalidCodeRecovery")]
        InvalidCodeRecovery = 5,
        [Description("ClientCodeNotFound")]
        ClientCodeNotFound = 6,
        [Description("ClientCodeFound")]
        ClientCodeFound = 7,
        [Description("InvalidCuit")]
        InvalidCuit = 8
    }
}
