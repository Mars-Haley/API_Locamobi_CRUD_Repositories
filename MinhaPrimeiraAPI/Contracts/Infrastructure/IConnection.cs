using MySql.Data.MySqlClient;
using System.Threading.Tasks.Dataflow;

namespace MinhaPrimeiraAPI.Contracts.Infrastructure
{
    public interface IConnection
    {
        MySqlConnection GetConnection();
        Task<int> Execute(string sql, object obj);
    
    }
}
