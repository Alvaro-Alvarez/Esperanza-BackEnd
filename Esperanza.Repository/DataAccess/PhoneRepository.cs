using Esperanza.Core.Interfaces.DataAccess;
using Esperanza.Core.Models;
using Esperanza.Repository.Constants;

namespace Esperanza.Repository.DataAccess
{
    public class PhoneRepository : GenericRepository<Phone>, IPhoneRepository
    {
        private readonly IConnectionBuilder ConnectionBuilder;

        public PhoneRepository(
            IConnectionBuilder connectionBuilder
            ) : base(Table.Phone, connectionBuilder)
        {
            ConnectionBuilder = connectionBuilder;
        }
    }
}
