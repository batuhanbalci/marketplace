using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Data.SqlClient;
using Dapper;
using System.Data;
using System.Data.SqlTypes;

namespace MarketplaceBlazorApp.DataEngine
{
    public class DapperORM
    {
        private static readonly string connectionString = "Server=.\\SQLExpress;Database=marketplace;Trusted_Connection=True;";

        public static string GetConnectionString()
        {
            return connectionString;
        }

        public static void ExecuteWithoutReturn(string procedureName, DynamicParameters param)
        {
            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                conn.Open();
                conn.Execute(procedureName, param, commandType: System.Data.CommandType.StoredProcedure);
            }
        }

        public static async Task ExecuteWithoutReturnAsync(string procedureName, DynamicParameters param)
        {
            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                await conn.OpenAsync();
                await conn.ExecuteAsync(procedureName, param, commandType: System.Data.CommandType.StoredProcedure);
            }
        }

        public static T ExecuteReturnScalar<T>(string procedureName, DynamicParameters param)
        {
            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                conn.Open();
                return (T)Convert.ChangeType(conn.ExecuteScalar(procedureName, param, commandType: System.Data.CommandType.StoredProcedure), typeof(T));
            }
        }

        public static async Task<T> ExecuteReturnScalarAsync<T>(string procedureName, DynamicParameters param)
        {
            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                await conn.OpenAsync();
                return (T)Convert.ChangeType(conn.ExecuteScalarAsync(procedureName, param, commandType: System.Data.CommandType.StoredProcedure), typeof(T));
            }
        }

        public static IEnumerable<T> ReturList<T>(string procedureName, DynamicParameters param = null)
        {
            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                conn.Open();
                return conn.Query<T>(procedureName, param, commandType: System.Data.CommandType.StoredProcedure);
            }
        }

        public static async Task<IEnumerable<T>> ReturListAsync<T>(string procedureName, DynamicParameters param = null)
        {
            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                await conn.OpenAsync();
                return await conn.QueryAsync<T>(procedureName, param, commandType: System.Data.CommandType.StoredProcedure);
            }
        }
    }
}
