using MySql.Data.MySqlClient;
using System.Threading.Tasks;

namespace MinhaPrimeiraAPI.Contracts.Infrastructure
{
    public interface IConnection
    { 
        MySqlConnection GetConnection();
        Task<int> Execute(string sql, object obj);
    }
}
