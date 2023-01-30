using Dapper;
using Esperanza.Core.Interfaces.DataAccess;
using Esperanza.Core.Models;
using Esperanza.Repository.Constants;
using System.Data;

namespace Esperanza.Repository.DataAccess
{
    public class EmailTemplateRepository : GenericRepository<EmailTemplate>, IEmailTemplateRepository
    {
        private readonly IConnectionBuilder _connectionBuilder;

        public EmailTemplateRepository(IConnectionBuilder connectionBuilder) : base(Table.EmailTemplate, connectionBuilder)
        {
            _connectionBuilder = connectionBuilder;
        }

        public async Task<EmailTemplate> GetByType(string emailType)
        {
            EmailTemplate template;
            using (IDbConnection db = _connectionBuilder.GetConnection())
            {
                template = (await db.QueryAsync<EmailTemplate>(EmailTemplate.GetByEmailType, new { EmailType = emailType })).FirstOrDefault();
            }
            return template;
        }
    }
}
