using Dapper;
using Esperanza.Core.Interfaces.DataAccess;
using Esperanza.Core.Models;
using Esperanza.Repository.Constants;
using System.Data;

namespace Esperanza.Repository.DataAccess
{
    public class EmailKeysRepository : GenericRepository<EmailKeys>, IEmailKeysRepository
    {
        private readonly IConnectionBuilder _connectionBuilder;

        public EmailKeysRepository(IConnectionBuilder connectionBuilder) : base(Table.EmailKeys, connectionBuilder)
        {
            _connectionBuilder = connectionBuilder;
        }

        public async Task<List<EmailKeys>> GetByTemplate(Guid idTemplate)
        {
            List<EmailKeys> keys;
            using (IDbConnection db = _connectionBuilder.GetConnection())
            {
                keys = (await db.QueryAsync<EmailKeys>(EmailKeys.GetKeyByTemplateId, new { IdTemplate = idTemplate })).ToList();
            }
            return keys;
        }
    }
}
