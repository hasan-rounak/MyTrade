using Dapper;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Threading.Tasks;

namespace MyTrade.Infra
{
    public class RepositoryBase
    {
        private readonly string connectionString;

        public RepositoryBase(string connectionString)
        {
            this.connectionString = connectionString;
        }

        public async Task<T> GetAssociationAsync<T>(string query, DynamicParameters dp, string StorecProcedureName = "") where T : class
        {
            await using SqlConnection conenction = new(this.connectionString);
            SqlMapper.AddTypeHandler(new JsonTypeHandler<T>());

            if (string.IsNullOrEmpty(StorecProcedureName))
            {
                return await conenction.QuerySingleOrDefaultAsync<T>(query, dp);
            }

            return await conenction.QuerySingleOrDefaultAsync<T>
            (
                StorecProcedureName,
                dp, commandType: CommandType.StoredProcedure
            );
        }

        public async Task<T> GetAsync<T>(string query, DynamicParameters dp, string StorecProcedureName = "") where T : class
        {
            await using SqlConnection conenction = new SqlConnection(this.connectionString);
            SqlMapper.ResetTypeHandlers();

            if (string.IsNullOrEmpty(StorecProcedureName))
            {
                return await conenction.QuerySingleOrDefaultAsync<T>(query, dp);
            }

            return await conenction.QuerySingleOrDefaultAsync<T>
            (
                StorecProcedureName,
                dp, commandType: CommandType.StoredProcedure
            );
        }

        public async Task<IEnumerable<T>> GetListAsync<T>(string query, DynamicParameters dp, string StorecProcedureName = "") where T : class
        {
            await using SqlConnection conenction = new SqlConnection(this.connectionString);
            SqlMapper.ResetTypeHandlers();

            if (string.IsNullOrEmpty(StorecProcedureName))
            {
                return await conenction.QueryAsync<T>(query, dp);
            }

            return await conenction.QueryAsync<T>
            (
                StorecProcedureName,
                dp, commandType: CommandType.StoredProcedure
            );
        }
    }
}
