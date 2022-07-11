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

        public async Task<List<AppUser>> GetAllFull()
        {
            List<AppUser> users;
            using (IDbConnection db = ConnectionBuilder.GetConnection())
            {
                users = (await db.QueryAsync<AppUser, UserRole, Person, DocumentType, Sex, Phone, AppUser>(
                    AppUser.GetAllFull, (user, role, person, documentType, sex, phone) =>
                    {
                        user.UserRole = role;
                        user.Person = person;
                        user.Person.DocumentType = documentType;
                        user.Person.Sex = sex;
                        user.Person.Phone = phone;
                        return user;
                    }, splitOn: "Guid,Guid,Guid,Guid,Guid")).ToList();
            }
            return users;
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

        public async Task<bool> Exist(string email, string clientCode)
        {
            int rows;
            using (IDbConnection db = ConnectionBuilder.GetConnection())
            {
                rows = (await db.QueryAsync<int>(AppUser.Exist, new { Email = email, BasClientCode = clientCode })).FirstOrDefault();
            }
            return rows > 0;
        }
    }
}
