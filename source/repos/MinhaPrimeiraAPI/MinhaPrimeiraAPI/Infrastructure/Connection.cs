
using MySql.Data.MySqlClient;
using Dapper;
using MinhaPrimeiraAPI.Contracts.Infrastructure;

namespace Crudzin.Infrastructure
{
    public class Connection : IConnection
    {
        protected string connectionString = "Server=localhost;Database=mydb;User=root;Password=root;";

       public MySqlConnection GetConnection()
        {
            return new MySqlConnection(connectionString);
        }

        public async Task<int> Execute(string sql, object obj)
        {
            using (MySqlConnection con = GetConnection())
            {
                return await con.ExecuteAsync(sql, obj);
            }
        }
    }
}
