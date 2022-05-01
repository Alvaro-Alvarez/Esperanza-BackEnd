using Esperanza.Core.Interfaces.DataAccess;
using Esperanza.Core.Models;
using Esperanza.Repository.Constants;

namespace Esperanza.Repository.DataAccess
{
    public class CountryRepository : GenericRepository<Country>, IGenericRepository<Country>
    {
        public CountryRepository(IConnectionBuilder connectionBuilder) : base(Table.Country, connectionBuilder)
        {

        }
    }
}
