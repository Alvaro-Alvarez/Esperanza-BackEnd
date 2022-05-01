using Esperanza.Core.Interfaces.DataAccess;
using Esperanza.Core.Models;
using Esperanza.Repository.Constants;

namespace Esperanza.Repository.DataAccess
{
    public class NeighborhoodRepository : GenericRepository<Neighborhood>, IGenericRepository<Neighborhood>
    {
        public NeighborhoodRepository(IConnectionBuilder connectionBuilder) : base(Table.Neighborhood, connectionBuilder)
        {

        }
    }
}
