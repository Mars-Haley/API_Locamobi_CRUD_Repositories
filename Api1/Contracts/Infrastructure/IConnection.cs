using MySql.Data.MySqlClient;

namespace Api1.Contracts.Infrastructure
{
    public interface IConnection
    {
        MySqlConnection GetConnection();
        Task<int> Execute(string sql, object obj);

    }
}
