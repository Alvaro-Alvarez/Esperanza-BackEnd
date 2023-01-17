using Esperanza.Core.Interfaces.DataAccess;
using Esperanza.Core.Models.Sync;
using Esperanza.Repository.Constants;

namespace Esperanza.Repository.DataAccess
{
    public class TransportSyncRepository : GenericRepository<TransportSync>, IGenericRepository<TransportSync>
    {
        public TransportSyncRepository(IConnectionBuilder connectionBuilder) : base(Table.TransportSync, connectionBuilder)
        {

        }
    }
}
