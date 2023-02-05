using Dapper;
using Esperanza.Core.Interfaces.DataAccess;
using Esperanza.Core.Models.Sync;
using Esperanza.Repository.Constants;
using System.Data;

namespace Esperanza.Repository.DataAccess
{
    public class CustomerConditionSyncRepository : GenericRepository<CustomerConditionSync>, ICustomerConditionSyncRepository
    {
        private readonly IConnectionBuilder ConnectionBuilder;

        public CustomerConditionSyncRepository(IConnectionBuilder connectionBuilder) : base(Table.CustomerConditionSync, connectionBuilder)
        {
            ConnectionBuilder = connectionBuilder;
        }

        public async Task<CustomerConditionSync> GetByClientAndCondition(string clientCode, string condition)
        {
            CustomerConditionSync customer;
            using (IDbConnection db = ConnectionBuilder.GetConnection())
            {
                customer = (await db.QueryAsync<CustomerConditionSync>(CustomerConditionSync.GetByClientAndCondition, new { ClientCode = clientCode, Condition = condition })).FirstOrDefault();
            }
            return customer;
        }
    }
}
