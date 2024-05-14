using Dapper;
using Microsoft.Data.SqlClient;
using System.Data;
using System.Data.Common;


namespace MovieLibrary.Repositories
{
    public class BaseRepository<T>
    {
        private readonly string _connectionString;

        public BaseRepository(string connectionString)
        {
            _connectionString = connectionString;
        }

        public IEnumerable<T> Get(string query, object parameters)
        {
            using var connection = new SqlConnection(_connectionString);
            return connection.Query<T>(query, parameters);
        }

        public IEnumerable<T> Get(string query)
        {
            using var connection = new SqlConnection(_connectionString);
            return connection.Query<T>(query);
        }
        public T GetById(string query, object parameters)
        {
            using var connection = new SqlConnection(_connectionString);
            return connection.QueryFirstOrDefault<T>(query, parameters);
        }

        public T StoredProcedure(string procedureName, object parameters)
        {
            using var connection = new SqlConnection(_connectionString);
            return connection.QuerySingleOrDefault<T>(procedureName, parameters, commandType: CommandType.StoredProcedure);

        }

        public void Delete(string query, object parameters)
        {
            using var connection = new SqlConnection(_connectionString);
            connection.Execute(query, parameters);
        }
    }
}
