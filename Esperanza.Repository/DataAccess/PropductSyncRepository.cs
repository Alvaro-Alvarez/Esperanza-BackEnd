using Esperanza.Core.Interfaces.DataAccess;
using Esperanza.Core.Models.Sync;
using Esperanza.Repository.Constants;

namespace Esperanza.Repository.DataAccess
{
    public class PropductSyncRepository : GenericRepository<PropductSync>, IGenericRepository<PropductSync>
    {
        public PropductSyncRepository(IConnectionBuilder connectionBuilder) : base(Table.PropductSync, connectionBuilder)
        {

        }
    }
}
