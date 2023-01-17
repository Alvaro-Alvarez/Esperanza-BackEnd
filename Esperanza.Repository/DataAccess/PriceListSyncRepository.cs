using Esperanza.Core.Interfaces.DataAccess;
using Esperanza.Core.Models.Sync;
using Esperanza.Repository.Constants;

namespace Esperanza.Repository.DataAccess
{
    public class PriceListSyncRepository : GenericRepository<PriceListSync>, IGenericRepository<PriceListSync>
    {
        public PriceListSyncRepository(IConnectionBuilder connectionBuilder) : base(Table.PriceListSync, connectionBuilder)
        {

        }
    }
}
