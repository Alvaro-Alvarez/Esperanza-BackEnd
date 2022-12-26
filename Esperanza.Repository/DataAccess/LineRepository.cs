using Dapper;
using Esperanza.Core.Interfaces.DataAccess;
using Esperanza.Core.Models;
using Esperanza.Repository.Constants;
using System.Data;

namespace Esperanza.Repository.DataAccess
{
    public class LineRepository : GenericRepository<Line>, ILineRepository
    {
        private readonly IConnectionBuilder ConnectionBuilder;

        public LineRepository(IConnectionBuilder connectionBuilder) : base(Table.Line, connectionBuilder)
        {
            ConnectionBuilder = connectionBuilder;
        }

        public async Task<List<Line>> GetAllByProductId(string productGuid)
        {
            List<Line> lines;
            using (IDbConnection db = ConnectionBuilder.GetConnection())
            {
                lines = (await db.QueryAsync<Line>(ProductLine.GetAllByProductId, new { ProductGuid = productGuid })).ToList();
            }
            return lines;
        }

        public async Task InsertManyToMany(List<Guid> guids, Guid productGuid)
        {
            foreach (var guid in guids)
            {
                using (IDbConnection db = ConnectionBuilder.GetConnection())
                {
                    await db.ExecuteAsync(ProductLine.Insert, new { ProductGuid = productGuid, LineGuid = guid });
                }
            }
        }
    }
}
