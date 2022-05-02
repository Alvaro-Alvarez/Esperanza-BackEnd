using Esperanza.Core.Interfaces.DataAccess;
using Esperanza.Core.Models;
using Esperanza.Repository.Constants;

namespace Esperanza.Repository.DataAccess
{
    public class PrincipalImageRepository : GenericRepository<PrincipalImage>, IPrincipalImageRepository
    {
        private readonly IConnectionBuilder ConnectionBuilder;

        public PrincipalImageRepository(
            IConnectionBuilder connectionBuilder
            ) : base(Table.PrincipalImage, connectionBuilder)
        {
            ConnectionBuilder = connectionBuilder;
        }
    }
}
