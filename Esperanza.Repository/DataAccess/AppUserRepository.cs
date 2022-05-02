using Dapper;
using Esperanza.Core.Interfaces.DataAccess;
using Esperanza.Core.Models;
using Esperanza.Repository.Constants;
using System.Data;

namespace Esperanza.Repository.DataAccess
{
    public class AppUserRepository : GenericRepository<AppUser>, IAppUserRepository
    {
        private readonly IConnectionBuilder ConnectionBuilder;

        public AppUserRepository(
            IConnectionBuilder connectionBuilder
            ) : base(Table.AppUser, connectionBuilder)
        {
            ConnectionBuilder = connectionBuilder;
        }

        public async Task<AppUser> GetUserAsync(Guid userGuid)
        {
            AppUser user;
            using (IDbConnection db = ConnectionBuilder.GetConnection())
            {
                user = (await db.QueryAsync<AppUser, UserRole, AppUser>(
                    AppUser.GetByGuid, (user, role) =>
                    {
                        user.UserRole = role;
                        return user;
                    }, new { Guid = userGuid }, splitOn: "Guid")).FirstOrDefault();
            }
            return user;
        }

        public async Task<AppUser> GetUserByEmailAsync(string email)
        {
            AppUser user;
            using (IDbConnection db = ConnectionBuilder.GetConnection())
            {
                user = (await db.QueryAsync<AppUser, UserRole, AppUser>(
                    AppUser.GetByEmail, (user, role) =>
                    {
                        user.UserRole = role;
                        return user;
                    }, new { Email = email }, splitOn: "Guid")).FirstOrDefault();
            }
            return user;
        }
    }
}
