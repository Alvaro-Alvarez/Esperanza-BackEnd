using Dapper;
using Esperanza.Core.Interfaces.DataAccess;
using Esperanza.Core.Models;
using Esperanza.Repository.Constants;
using System.Data;

namespace Esperanza.Repository.DataAccess
{
    public class ErrorsRepository : GenericRepository<Errors>, IErrorsRepository
    {
        private readonly IConnectionBuilder ConnectionBuilder;

        public ErrorsRepository(
            IConnectionBuilder connectionBuilder
            ) : base(Table.Errors, connectionBuilder)
        {
            ConnectionBuilder = connectionBuilder;
        }

        public async Task<string> InsertError(Errors error)
        {
            int id;
            using (IDbConnection db = ConnectionBuilder.GetConnection())
            {
                await db.ExecuteAsync(Errors.InsertError, new {
                    error.Guid,
                    error.Deleted,
                    error.CreatedAt,
                    error.UpdatedAt,
                    error.CreatedBy,
                    error.UpdatedBy,
                    error.Message,
                    error.StackTrace
                });
                //id = (await db.QueryAsync<int>(Errors.GetLasId)).FirstOrDefault();
            }
            return error.Guid.ToString();
        }
    }
}
