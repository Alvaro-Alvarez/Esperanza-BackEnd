using Esperanza.Core.Interfaces.DataAccess;
using Esperanza.Core.Models;
using Esperanza.Repository.Constants;

namespace Esperanza.Repository.DataAccess
{
    public class SupplierItemRepository : GenericRepository<SupplierItem>, IGenericRepository<SupplierItem>
    {
        public SupplierItemRepository(IConnectionBuilder connectionBuilder) : base(Table.SupplierItem, connectionBuilder)
        {

        }
    }
}
