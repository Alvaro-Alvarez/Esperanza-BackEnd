using Esperanza.Core.Constants;

namespace Esperanza.Core.Interfaces.Business
{
    public interface IEmailService
    {
        Task<bool> SendMail(string emailType, Dictionary<string, string> values, List<string> tos);
    }
}
