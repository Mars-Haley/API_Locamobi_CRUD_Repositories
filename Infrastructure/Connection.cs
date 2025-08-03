using Dapper;
using MySql.Data.MySqlClient;
using Locamobi.Contracts.Infrastructure;

namespace Locamobi.Infrastructure
{
    public class Connection : IConnection
    {
        //protected string connectionString = "Server=localhost;Database=locamobi;User=root;Password=root;";
        protected string connectionString = "Server=3306;Database=locamobi;User=root;Password=root;";

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