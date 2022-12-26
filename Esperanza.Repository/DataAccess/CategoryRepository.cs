using Dapper;
using Esperanza.Core.Interfaces.DataAccess;
using Esperanza.Core.Models;
using Esperanza.Repository.Constants;
using System.Data;

namespace Esperanza.Repository.DataAccess
{
    public class CategoryRepository : GenericRepository<Category>, ICategoryRepository
    {
        private readonly IConnectionBuilder ConnectionBuilder;

        public CategoryRepository(IConnectionBuilder connectionBuilder) : base(Table.Category, connectionBuilder)
        {
            ConnectionBuilder = connectionBuilder;
        }

        public async Task<List<Category>> GetAllByProductId(string productGuid)
        {
            List<Category> categories;
            using (IDbConnection db = ConnectionBuilder.GetConnection())
            {
                categories = (await db.QueryAsync<Category>(ProductCategory.GetAllByProductId, new { ProductGuid = productGuid })).ToList();
            }
            return categories;
        }

        public async Task InsertManyToMany(List<Guid> guids, Guid productGuid)
        {
            foreach (var guid in guids)
            {
                using (IDbConnection db = ConnectionBuilder.GetConnection())
                {
                    await db.ExecuteAsync(ProductCategory.Insert, new { ProductGuid = productGuid, CategoryGuid = guid });
                }
            }
        }
    }
}
