using Esperanza.Core.Interfaces.DataAccess;
using Esperanza.Core.Models;
using Esperanza.Repository.Constants;

namespace Esperanza.Repository.DataAccess
{
    public class ListRepository : GenericRepository<List>, IGenericRepository<List>
    {
        public ListRepository(IConnectionBuilder connectionBuilder) : base(Table.List, connectionBuilder)
        {

        }
    }
}
