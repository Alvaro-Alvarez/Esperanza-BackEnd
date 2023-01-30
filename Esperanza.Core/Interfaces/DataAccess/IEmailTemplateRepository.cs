using Esperanza.Core.Models;

namespace Esperanza.Core.Interfaces.DataAccess
{
    public interface IEmailTemplateRepository : IGenericRepository<EmailTemplate>
    {
        Task<EmailTemplate> GetByType(string emailType);
    }
}
