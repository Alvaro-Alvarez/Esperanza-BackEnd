using Esperanza.Core.Interfaces.DataAccess;
using Esperanza.Core.Models;
using Esperanza.Repository.Constants;

namespace Esperanza.Repository.DataAccess
{
    public class UpSellingRepository : GenericRepository<UpSelling>, IUpSellingRepository
    {
        private readonly IConnectionBuilder ConnectionBuilder;

        public UpSellingRepository(
            IConnectionBuilder connectionBuilder
            ) : base(Table.UpSelling, connectionBuilder)
        {
            ConnectionBuilder = connectionBuilder;
        }
    }
}
