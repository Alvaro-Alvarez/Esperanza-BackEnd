using Esperanza.Core.Interfaces.DataAccess;
using Esperanza.Core.Models;
using Esperanza.Repository.Constants;

namespace Esperanza.Repository.DataAccess
{
    public class KindRepository : GenericRepository<Kind>, IGenericRepository<Kind>
    {
        public KindRepository(IConnectionBuilder connectionBuilder) : base(Table.Kind, connectionBuilder)
        {

        }
    }
}
