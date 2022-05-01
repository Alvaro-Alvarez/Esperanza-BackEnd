using Esperanza.Core.Interfaces.DataAccess;
using Esperanza.Core.Models;
using Esperanza.Repository.Constants;

namespace Esperanza.Repository.DataAccess
{
    public class CityRepository : GenericRepository<City>, IGenericRepository<City>
    {
        public CityRepository(IConnectionBuilder connectionBuilder) : base(Table.City, connectionBuilder)
        {

        }
    }
}
