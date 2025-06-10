
using MySql.Data.MySqlClient;
using Dapper;

namespace Crudzin.Infrastructure
{
    public class Connection
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
