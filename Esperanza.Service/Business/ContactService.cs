using Esperanza.Core.Constants;
using Esperanza.Core.Interfaces.Business;
using Esperanza.Core.Models;
using Esperanza.Core.Options;
using Microsoft.Extensions.Options;
using System.Net;

namespace Esperanza.Service.Business
{
    public class ContactService : IContactService
    {
        private readonly IEmailService _emailService;
        private readonly IReCaptcharService ReCaptcharService;
        private readonly EmailOptions EmailSettings;

        public ContactService(
            IEmailService emailService,
            IOptions<EmailOptions> emailSettings,
            IReCaptcharService reCaptcharService)
        {
            _emailService = emailService;
            EmailSettings = emailSettings.Value;
            ReCaptcharService = reCaptcharService;
        }

        public async Task SendContactMessage(ContactMessage message)
        {
            //if (!await ReCaptcharService.Validate(message.ReCaptchaToken)) throw new Exception("Recaptcha inválido");
            await _emailService.SendMail(
                emailType: EmailTypeConstant.MessageContact,
                values: new Dictionary<string, string>
                {
                    { "BusinessName", message.BusinessName },
                    { "Email", message.Email },
                    { "Phone", message.PhonenNumber },
                    { "Location", message.Location },
                    { "Address", message.Address },
                    { "Activity", message.Activity },
                    { "Subject", message.Subjet },
                    { "Message", message.Message },
                },
                tos: new List<string>() { EmailSettings.ContactEmail });
        }
    }
}
