using Esperanza.Core.Interfaces.DataAccess;
using Esperanza.Core.Models.Options;
using Microsoft.Extensions.Options;
using System.Data.SqlClient;

namespace Esperanza.Repository.DataAccess
{
    public class ConnectionBuilder : IConnectionBuilder
    {
        private readonly DBOptions Options;

        public ConnectionBuilder(IOptions<DBOptions> options)
        {
            Options = options.Value;
        }

        public SqlConnection GetConnection()
        {
            try
            {
                return new SqlConnection(Options.ConnectionString);
            }
            catch (Exception)
            {
                throw;
            }
        }
    }
}
