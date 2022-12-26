using Dapper;
using Esperanza.Core.Interfaces.DataAccess;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Reflection;
using System.Text;

namespace Esperanza.Repository.DataAccess
{
    public abstract class GenericRepository<T> : IGenericRepository<T> where T : class
    {
        private readonly string TableName;
        private readonly IConnectionBuilder ConnectionBuilder;

        protected GenericRepository(string tableName, IConnectionBuilder connectionBuilder)
        {
            TableName = tableName;
            ConnectionBuilder = connectionBuilder;
        }

        #region Public Methods

        public virtual async Task<IEnumerable<T>> GetAllAsync(bool withDelete = true)
        {
            using (var connection = CreateConnection())
            {
                string query = $"SELECT * FROM {TableName}";
                query += withDelete ? " WHERE Deleted = 0" : string.Empty;
                return await connection.QueryAsync<T>(query);
            }
        }

        public virtual async Task<IEnumerable<T>> GetByRangeIds(string query, string adId)
        {
            using (var connection = CreateConnection())
            {
                return await connection.QueryAsync<T>(query, new { IdAdvertisement = adId });
            }
        }

        public virtual async Task<T> GetByName(string name)
        {
            using (var connection = CreateConnection())
            {
                var result = await connection.QuerySingleOrDefaultAsync<T>($"SELECT * FROM {TableName} WHERE Name = '{name}' AND Deleted = 0");
                return result;
            }
        }

        public virtual async Task<IEnumerable<T>> GetRangeByName(List<string> names)
        {
            using (var connection = CreateConnection())
            {
                string query = $"SELECT * FROM {TableName} WHERE Name IN @Names AND Deleted = 0";
                return await connection.QueryAsync<T>(query, new { Names = names });
            }
        }

        public virtual async Task DeleteRowAsync(string id)
        {
            using (var connection = CreateConnection())
            {
                await connection.ExecuteAsync($"UPDATE {TableName} SET DEL = 1 WHERE Id=@Id", new { Id = id });
            }
        }

        public virtual async Task DeleteIntermediate(string idAd, string query)
        {
            using (var connection = CreateConnection())
            {
                await connection.ExecuteAsync(query, new { IdAdvertisement = idAd });
            }
        }

        public virtual async Task<T> GetAsync(string id)
        {
            using (var connection = CreateConnection())
            {
                var result = await connection.QuerySingleOrDefaultAsync<T>($"SELECT * FROM {TableName} WHERE Guid=@Id AND Deleted = 0", new { Id = id });
                if (result == null)
                    throw new KeyNotFoundException($"{TableName} with id [{id}] could not be found.");

                return result;
            }
        }

        public virtual async Task<int> SaveRangeAsync(IEnumerable<T> list)
        {
            var inserted = 0;
            var query = GenerateInsertQuery();
            using (var connection = CreateConnection())
            {
                inserted += await connection.ExecuteAsync(query, list);
            }

            return inserted;
        }

        public virtual async Task InsertAsync(T t)
        {
            var insertQuery = GenerateInsertQuery();

            using (var connection = CreateConnection())
            {
                using (IDbTransaction trx = connection.BeginTransaction())
                {
                    await connection.ExecuteAsync(insertQuery, t, trx);
                    trx.Commit();
                }
            }
        }

        public virtual async Task UpdateAsync(T t)
        {
            var updateQuery = GenerateUpdateQuery();

            using (var connection = CreateConnection())
            {
                await connection.ExecuteAsync(updateQuery, t);
            }
        }

        public virtual async Task<int> GetLastId()
        {
            using (var connection = CreateConnection())
            {
                var ids = await connection.QueryAsync<int>($"select top 1 id from {TableName} order by id desc");
                return ids.FirstOrDefault();
            }
        }

        #endregion

        #region Private Methods
        /// <summary>
        /// Generate new connection based on connection string
        /// </summary>
        /// <returns></returns>
        private SqlConnection SqlConnection()
        {
            return ConnectionBuilder.GetConnection();
        }

        /// <summary>
        /// Open new connection and return it for use
        /// </summary>
        /// <returns></returns>
        private IDbConnection CreateConnection()
        {
            var conn = SqlConnection();
            if (conn.State == ConnectionState.Closed)
            {
                conn.Open();
            }

            return conn;
        }

        private IEnumerable<PropertyInfo> GetProperties => typeof(T).GetProperties();

        private static List<string> GenerateListOfProperties(IEnumerable<PropertyInfo> listOfProperties)
        {
            return (from prop in listOfProperties
                    let attributes = prop.GetCustomAttributes(typeof(DescriptionAttribute), false)
                    where attributes.Length <= 0 || (attributes[0] as DescriptionAttribute)?.Description != "ignore"
                    select prop.Name).ToList();
        }

        private static string GetNameKey(IEnumerable<PropertyInfo> listOfProperties)
        {
            return (from prop in listOfProperties
                    let attributes = prop.GetCustomAttributes(typeof(DescriptionAttribute), false)
                    where attributes.Length > 0 && (attributes[0] as DescriptionAttribute).Description == "key"
                    select prop.Name).SingleOrDefault();
        }

        private string GenerateInsertQuery()
        {
            var insertQuery = new StringBuilder($"INSERT INTO {TableName} ");
            insertQuery.Append("(");
            var keyName = GetNameKey(GetProperties);
            var properties = GenerateListOfProperties(GetProperties);
            properties.ForEach(prop => { insertQuery.Append($"{prop},"); });
            insertQuery
                .Remove(insertQuery.Length - 1, 1)
                .Append(") VALUES (");
            properties.ForEach(prop => { insertQuery.Append($"@{prop},"); });

            insertQuery
                .Remove(insertQuery.Length - 1, 1)
                .Append(")");
            return insertQuery.ToString();
        }

        private string GenerateUpdateQuery()
        {
            var updateQuery = new StringBuilder($"UPDATE {TableName} SET ");
            var properties = GenerateListOfProperties(GetProperties);
            var keyName = GetNameKey(GetProperties);
            properties.ForEach(property =>
            {
                if ((!string.IsNullOrEmpty(keyName) && !property.Equals(keyName) && !property.Equals("Created_At") && !property.Equals("Deleted_At")) || properties.Contains("guid"))
                {
                    updateQuery.Append($"{property}=@{property},");
                }
            });

            updateQuery.Remove(updateQuery.Length - 1, 1); //remove last comma

            if (!string.IsNullOrEmpty(keyName))
            {
                updateQuery.Append($" WHERE {keyName}=@{keyName}");
            }
            else if (properties.Contains("guid"))
            {
                updateQuery.Append(" WHERE guid=:guid");
            }
            else
            {
                updateQuery.Append(" WHERE Id=:Id");
            }

            return updateQuery.ToString();
        }

        #endregion
    }
}
