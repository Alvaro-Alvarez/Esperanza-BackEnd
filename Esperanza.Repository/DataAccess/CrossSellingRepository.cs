using Esperanza.Core.Interfaces.DataAccess;
using Esperanza.Core.Models;
using Esperanza.Repository.Constants;

namespace Esperanza.Repository.DataAccess
{
    public class CrossSellingRepository : GenericRepository<CrossSelling>, ICrossSellingRepository
    {
        private readonly IConnectionBuilder ConnectionBuilder;

        public CrossSellingRepository(
            IConnectionBuilder connectionBuilder
            ) : base(Table.CrossSelling, connectionBuilder)
        {
            ConnectionBuilder = connectionBuilder;
        }
    }
}
