using Locamobi.Contracts.Repository;
using Locamobi.DTO_;
using Dapper;
using Locamobi.Contracts.Infrastructure;
using Locamobi.Entity;
using Locamobi.Infrastructure;
using MySql.Data.MySqlClient;

namespace Locamobi.Repository
{
    public class CityRepository : ICityRepository
    {

        private IConnection _connection;

        public CityRepository(IConnection connection)
        {
            _connection = connection;
        }

        public async Task<IEnumerable<CityEntity>> GetAll()
        {
            using (MySqlConnection con = _connection.GetConnection())
            {
                string sql = @$"
                        SELECT CODCID AS {nameof(CityEntity.Id)},
                            NOMECID AS {nameof(CityEntity.Name)},
                            UF AS {nameof(CityEntity.UF)} 
                        FROM CIDADE
                    ";

                IEnumerable<CityEntity> cityList = await con.QueryAsync<CityEntity>(sql);
                return cityList;
            }
        }

        public async Task Insert(CityInsertDTO city)
        {
            string sql = $@"
                       INSERT INTO CIDADE(NOMECID, UF)
                       VALUE(@Name, @UF)";

            using (MySqlConnection con = _connection.GetConnection())
            {
                await con.ExecuteAsync(sql, city);

            }
        }

        public async Task Delete(int id)
        {
            Connection _connection = new Connection();
            string sql = @$"
                            DELETE FROM CIDADE 
                            WHERE CODCID = @Id
                            ";
            await _connection.Execute(sql, new {id});

        }

        public async Task<CityEntity> GetById(int id)
        {
            using (MySqlConnection con = _connection.GetConnection())
            {
                string sql = @$"
                             SELECT CODCID AS {nameof(CityEntity.Id)},
                            NOMECID AS {nameof(CityEntity.Name)},
                            UF AS {nameof(CityEntity.UF)} 
                            FROM CIDADE
                            WHERE CODCID = @id
                            ";

                CityEntity city = await con.QueryFirstAsync<CityEntity>(sql, new { id });
                return city;
            }
        }

        public async Task Update(CityEntity city)
        {
            string sql = @$"
                         UPDATE CIDADE 
                         SET NOMECID = @NOMECID,
                             UF = @UF
                         WHERE CODCID = @CODCID 
                         ";


            using (MySqlConnection con = _connection.GetConnection())
            {
                await con.ExecuteAsync(sql, city);
            }
        }
    }
   
}



