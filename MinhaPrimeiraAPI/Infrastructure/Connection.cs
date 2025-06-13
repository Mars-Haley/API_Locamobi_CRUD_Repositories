using Dapper;
using MinhaPrimeiraAPI.Contracts.Infrastructure;
using MySql.Data.MySqlClient;

namespace MeuPrimeiroCrud.Infrastructure
{
    public class Connection: IConnection
    {
        
        protected string connectionString = "Server=localhost;Database=locamobi;User=root;Password=root;";

        public MySqlConnection GetConnection()
        {
            return new MySqlConnection(connectionString);
        }

        public async Task<int> Execute(string sql, object obj)
        {
            using var con = GetConnection();
            return await con.ExecuteAsync(sql, obj);
        }

    }
}