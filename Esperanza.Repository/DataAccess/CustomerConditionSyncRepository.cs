using Esperanza.Core.Interfaces.DataAccess;
using Esperanza.Core.Models.Sync;
using Esperanza.Repository.Constants;

namespace Esperanza.Repository.DataAccess
{
    public class CustomerConditionSyncRepository : GenericRepository<CustomerConditionSync>, IGenericRepository<CustomerConditionSync>
    {
        public CustomerConditionSyncRepository(IConnectionBuilder connectionBuilder) : base(Table.CustomerConditionSync, connectionBuilder)
        {

        }
    }
}
