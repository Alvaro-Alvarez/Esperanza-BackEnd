using Esperanza.Core.Interfaces.DataAccess;
using Esperanza.Core.Models;
using Esperanza.Repository.Constants;

namespace Esperanza.Repository.DataAccess
{
    public class VademecumRepository : GenericRepository<Vademecum>, IGenericRepository<Vademecum>
    {
        public VademecumRepository(IConnectionBuilder connectionBuilder) : base(Table.Vademecum, connectionBuilder)
        {

        }
    }
}
