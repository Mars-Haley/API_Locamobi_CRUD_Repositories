using Locamobi.Contracts.Repository;
using Locamobi.DTO_;
using Dapper;
using Locamobi.Contracts.Infrastructure;
using Locamobi.Entity;
using MySql.Data.MySqlClient;
using User.DTO;

namespace Locamobi.Repository
{
    public class PictureRepository : IPictureRepository
    {
        private IConnection _connection;

        public PictureRepository(IConnection connection)
        {
            _connection = connection;
        }

        public async Task<IEnumerable<PictureEntity>> GetAll()
        {
            using (MySqlConnection con = _connection.GetConnection())
            {
                string sql = @$"
                    SELECT CODFOTO AS {nameof(PictureEntity.Id)},
                           FOTO AS {nameof(PictureEntity.Path)}
                    FROM FOTO
                ";

                IEnumerable<PictureEntity> pictures = await con.QueryAsync<PictureEntity>(sql);
                return pictures;
            }
        }

        public async Task<PictureEntity> GetById(int id)
        {
            using (MySqlConnection con = _connection.GetConnection())
            {
                string sql = @$"
                    SELECT CODFOTO AS {nameof(PictureEntity.Id)},
                           FOTO AS {nameof(PictureEntity.Path)}
                    FROM FOTO
                    WHERE CODFOTO = @id
                ";

                PictureEntity picture = await con.QueryFirstAsync<PictureEntity>(sql, new { id });
                return picture;
            }
        }

        public async Task Insert(PictureInsertDTO picture)
        {
            string sql = @$"
                INSERT INTO FOTO(FOTO)
                VALUES(@Path)
            ";

            using (MySqlConnection con = _connection.GetConnection())
            {
                await con.ExecuteAsync(sql, picture);
            }
        }

        public async Task Update(PictureEntity picture)
        {
            string sql = @$"
                UPDATE FOTO
                SET FOTO = @Path
                WHERE CODFOTO = @Id
            ";

            using (MySqlConnection con = _connection.GetConnection())
            {
                await con.ExecuteAsync(sql, picture);
            }
        }

        public async Task Delete(int id)
        {
            using (MySqlConnection con = _connection.GetConnection())
            {
                string sql = @$"
                    DELETE FROM FOTO
                    WHERE CODFOTO = @Id
                ";

                await con.ExecuteAsync(sql, new { id });
            }
        }
    }
}
