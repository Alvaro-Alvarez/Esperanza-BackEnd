using Esperanza.Core.Interfaces.DataAccess;
using Esperanza.Core.Models;
using Esperanza.Repository.Constants;

namespace Esperanza.Repository.DataAccess
{
    public class UserRoleRepository : GenericRepository<UserRole>, IGenericRepository<UserRole>
    {
        public UserRoleRepository(IConnectionBuilder connectionBuilder) : base(Table.UserRole, connectionBuilder)
        {

        }
    }
}
