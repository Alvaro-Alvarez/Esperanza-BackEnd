using Dapper;
using Esperanza.Core.Interfaces.DataAccess;
using Esperanza.Core.Models;
using Esperanza.Repository.Constants;
using System.Data;

namespace Esperanza.Repository.DataAccess
{
    public class KindRepository : GenericRepository<Kind>, IKindRepository
    {
        private readonly IConnectionBuilder ConnectionBuilder;

        public KindRepository(IConnectionBuilder connectionBuilder) : base(Table.Kind, connectionBuilder)
        {
            ConnectionBuilder = connectionBuilder;
        }

        public async Task<List<Kind>> GetAllByProductId(string productGuid)
        {
            List<Kind> kinds;
            using (IDbConnection db = ConnectionBuilder.GetConnection())
            {
                kinds = (await db.QueryAsync<Kind>(ProductKind.GetAllByProductId, new { ProductGuid = productGuid})).ToList();
            }
            return kinds;
        }

        public async Task InsertManyToMany(List<Guid> guids, Guid productGuid)
        {
            foreach (var guid in guids)
            {
                using (IDbConnection db = ConnectionBuilder.GetConnection())
                {
                    await db.ExecuteAsync(ProductKind.Insert, new { ProductGuid = productGuid, KindGuid = guid });
                }
            }
        }
    }
}
