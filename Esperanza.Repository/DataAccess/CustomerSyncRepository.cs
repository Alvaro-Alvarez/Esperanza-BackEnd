using Esperanza.Core.Interfaces.DataAccess;
using Esperanza.Core.Models.Sync;
using Esperanza.Repository.Constants;

namespace Esperanza.Repository.DataAccess
{
    public class CustomerSyncRepository : GenericRepository<CustomerSync>, IGenericRepository<CustomerSync>
    {
        public CustomerSyncRepository(IConnectionBuilder connectionBuilder) : base(Table.CustomerSync, connectionBuilder)
        {

        }
    }
}
