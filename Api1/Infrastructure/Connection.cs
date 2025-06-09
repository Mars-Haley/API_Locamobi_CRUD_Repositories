using Dapper;
using MySql.Data.MySqlClient;

namespace Api1.Infrastructure
{
    public class Connection
    {
        protected string connectionString = "Server=localhost;Database=locamobi;User=root;Password=root;";

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