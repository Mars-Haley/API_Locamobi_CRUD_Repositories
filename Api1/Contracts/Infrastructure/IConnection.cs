using MySql.Data.MySqlClient;

namespace User.Contracts.Infrastructure
{
    public interface IConnection
    {
        MySqlConnection GetConnection();
        Task<int> Execute(string sql, object obj);
    }
}
