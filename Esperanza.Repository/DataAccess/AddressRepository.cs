using Esperanza.Core.Interfaces.DataAccess;
using Esperanza.Core.Models;
using Esperanza.Repository.Constants;

namespace Esperanza.Repository.DataAccess
{
    public class AddressRepository : GenericRepository<Address>, IAddressRepository
    {
        private readonly IConnectionBuilder ConnectionBuilder;

        public AddressRepository(
            IConnectionBuilder connectionBuilder
            ) : base(Table.Phone, connectionBuilder)
        {
            ConnectionBuilder = connectionBuilder;
        }
    }
}
