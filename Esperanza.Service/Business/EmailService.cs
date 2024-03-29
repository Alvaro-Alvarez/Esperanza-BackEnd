﻿using Esperanza.Core.Interfaces.Business;
using Esperanza.Core.Interfaces.DataAccess;
using Esperanza.Core.Models;
using Esperanza.Core.Options;
using Microsoft.Extensions.Options;
using System.Net.Mail;
using System.Net;
using Esperanza.Core.Logs;
using Newtonsoft.Json;

namespace Esperanza.Service.Business
{
    public class EmailService : IEmailService
    {
        private readonly IEmailTemplateRepository _emailTemplateRepository;
        private readonly IEmailKeysRepository _emailKeysRepository;
        private readonly EmailOptions EmailSettings;
        private readonly Logs LogsSettings;

        public EmailService(
            IEmailTemplateRepository emailTemplateRepository,
            IEmailKeysRepository emailKeysRepository,
            IOptions<EmailOptions> emailSettings,
            IOptions<Logs> logsSettings)
        {
            EmailSettings = emailSettings.Value;
            _emailTemplateRepository = emailTemplateRepository;
            _emailKeysRepository = emailKeysRepository;
            LogsSettings = logsSettings.Value;
        }

        public async Task<bool> SendMail(string emailType, Dictionary<string, string> values, List<string> tos)
        {
            var template = await GetEmailTemplateByType(emailType);
            var mail = new MailMessage();
            mail.From = new MailAddress(EmailSettings.From, EmailSettings.Name);
            //mail.To.Add(new MailAddress(tos.FirstOrDefault()));
            foreach (var to in tos)
                mail.To.Add(new MailAddress(to));
            mail.Subject = template.Subject;
            mail.Body = GetFullTemplateHtml(template, values);
            mail.IsBodyHtml = true;

            SmtpClient client = new SmtpClient(EmailSettings.Host, EmailSettings.Port.Value);
            client.Credentials = new NetworkCredential(EmailSettings.From, EmailSettings.Password);
            client.EnableSsl = true;
            Log.Information($"Antes de enviar mail --> {JsonConvert.SerializeObject(mail)}");
            client.Send(mail);
            return true;

        }
        #region Private Methods
        private string GetFullTemplateHtml(EmailTemplate template, Dictionary<string, string> values)
        {
            foreach (var emailKey in template.EmailKeys)
                template.Template = template.Template.Replace(emailKey.Key, values[emailKey.FieldNameValue]);
            return template.Template;
        }
        private async Task<EmailTemplate> GetEmailTemplateByType(string emailType)
        {
            var template = await _emailTemplateRepository.GetByType(emailType);
            template.EmailKeys = await _emailKeysRepository.GetByTemplate(template.Guid.Value);
            return template;
        }
        #endregion
    }
}
