using Esperanza.Core.Interfaces.DataAccess;
using Esperanza.Core.Models;
using Esperanza.Repository.Constants;

namespace Esperanza.Repository.DataAccess
{
    public class LaboratoryRepository : GenericRepository<Laboratory>, IGenericRepository<Laboratory>
    {
        public LaboratoryRepository(IConnectionBuilder connectionBuilder) : base(Table.Laboratory, connectionBuilder)
        {

        }
    }
}
