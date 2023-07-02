using Esperanza.Core.Interfaces.DataAccess;
using Esperanza.Core.Models;
using Esperanza.Repository.Constants;

namespace Esperanza.Repository.DataAccess
{
    public class ConditionTypeRepository : GenericRepository<ConditionType>, IConditionTypeRepository
    {
        private readonly IConnectionBuilder ConnectionBuilder;

        public ConditionTypeRepository(
            IConnectionBuilder connectionBuilder
            ) : base(Table.ConditionType, connectionBuilder)
        {
            ConnectionBuilder = connectionBuilder;
        }
    }
}
