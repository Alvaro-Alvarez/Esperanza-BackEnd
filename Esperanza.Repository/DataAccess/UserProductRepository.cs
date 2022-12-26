using Dapper;
using Esperanza.Core.Interfaces.DataAccess;
using Esperanza.Core.Models;
using Esperanza.Repository.Constants;
using System.Data;

namespace Esperanza.Repository.DataAccess
{
    public class UserProductRepository : GenericRepository<UserProduct>, IUserProductRepository
    {
        private readonly IConnectionBuilder ConnectionBuilder;

        public UserProductRepository(IConnectionBuilder connectionBuilder) : base(Table.UserProduct, connectionBuilder)
        {
            ConnectionBuilder = connectionBuilder;
        }

        public async Task<List<UserProduct>> GetAllByUser(string userGuid)
        {
            List<UserProduct> userProducts;
            using (IDbConnection db = ConnectionBuilder.GetConnection())
            {
                userProducts = (await db.QueryAsync<UserProduct>(UserProduct.GetAllByUser, new { UserGuid = userGuid })).ToList();
            }
            return userProducts;
        }
    }
}
