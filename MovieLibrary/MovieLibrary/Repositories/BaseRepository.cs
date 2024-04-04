using Dapper;
using Microsoft.Data.SqlClient;
using System.Data;

namespace MovieLibrary.Repositories
{
    public class BaseRepository<T> where T : class
    {
        private readonly string _connectionString;

        public BaseRepository(string connectionString)
        {
            _connectionString = connectionString;
        }

        public IEnumerable<T> QueryDB(string query, object parameters)
        {
            using var connection = new SqlConnection(_connectionString);
            return connection.Query<T>(query, parameters);
        }

        public T QueryDBSingle(string query, object parameters)
        {
            using var connection = new SqlConnection(_connectionString);
            return connection.QuerySingleOrDefault<T>(query, parameters);
        }

        public U ExecuteStoredProcedure<U>(string query, object parameters)
        {
            using var connection = new SqlConnection(_connectionString);
            return connection.QuerySingleOrDefault<U>(query, parameters, commandType: CommandType.StoredProcedure);
        }

        public int Create(string query, object parameters)
        {
            using var connection = new SqlConnection(_connectionString);
            var identity = connection.ExecuteScalar<int>(query, param: parameters);
            return identity;
        }

        public bool Delete(string query, object parameters)
        {
            using var connection = new SqlConnection(_connectionString);
            return connection.Execute(query, parameters) > 0;
        }

        public bool Update(string query, T parameters)
        {
            using var connection = new SqlConnection(_connectionString);
            return connection.Execute(query, parameters) > 0;
        }
    }
}
