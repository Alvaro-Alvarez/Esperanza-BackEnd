using Esperanza.Core.Interfaces.DataAccess;
using Esperanza.Core.Models;
using Esperanza.Repository.Constants;

namespace Esperanza.Repository.DataAccess
{
    public class SexRepository : GenericRepository<Sex>, IGenericRepository<Sex>
    {
        public SexRepository(IConnectionBuilder connectionBuilder) : base(Table.Sex, connectionBuilder)
        {

        }
    }
}
