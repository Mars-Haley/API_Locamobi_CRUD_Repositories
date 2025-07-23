using Dapper;
using Locamobi.Contracts.Infrastructure;
using Locamobi.Contracts.Repository;
using Locamobi.Entity;

namespace Locamobi.Repository
{
    public class RatingRepository : IRatingRepository
    {
        private readonly IConnection _connection;

        public RatingRepository(IConnection connection)
        {
            _connection = connection;
        }

        public async Task<IEnumerable<RatingEntity>> GetAllAsync()
        {
            var sql = @"
                SELECT
                    CODAVA as CodAvaliacao,
                    NOTA as Nota,
                    COMENT as Coment,
                    DATA as Data,
                    VEICULO_CODVEICULO as Veiculo_Id,
                    QUANTUSO as Quantuso
                FROM locamobi.avaliacao";

            using (var db = _connection.GetConnection())
            {
                return await db.QueryAsync<RatingEntity>(sql);
            }
        }

        public async Task<RatingEntity> GetByIdAsync(int id)
        {
            var sql = @"
                SELECT
                    CODAVA as CodAvaliacao,
                    NOTA as Nota,
                    COMENT as Coment,
                    DATA as Data,
                    VEICULO_CODVEICULO as Veiculo_Id,
                    QUANTUSO as Quantuso
                FROM locamobi.avaliacao
                WHERE CODAVA = @id";

            using (var db = _connection.GetConnection())
            {
                return await db.QueryFirstOrDefaultAsync<RatingEntity>(sql, new { id });
            }
        }

        public async Task<IEnumerable<RatingEntity>> GetByVeiculoCodAsync(int veiculoCod)
        {
            var sql = @"
                SELECT
                    CODAVA as CodAvaliacao,
                    NOTA as Nota,
                    COMENT as Coment,
                    DATA as Data,
                    VEICULO_CODVEICULO as Veiculo_Id,
                    QUANTUSO as Quantuso
                FROM locamobi.avaliacao
                WHERE VEICULO_CODVEICULO = @Veiculo_Id";

            using (var db = _connection.GetConnection())
            {
                return await db.QueryAsync<RatingEntity>(sql, new { veiculoCod });
            }
        }

        public async Task<IEnumerable<RatingEntity>> GetByUsuarioCodAsync(int usuarioCod)
        {
            var sql = @"
                SELECT
                    a.CODAVA as CodAvaliacao,
                    a.NOTA as Nota,
                    a.COMENT as Coment,
                    a.DATA as Data,
                    a.VEICULO_CODVEICULO as Veiculo_Id,
                    a.QUANTUSO as Quantuso,
                    u.NOME as NomeAvaliador,
                    v.MODELO as ModeloVeiculoAvaliado
                FROM locamobi.avaliacao a
                INNER JOIN locamobi.veiculo v ON v.CODVEICULO = a.VEICULO_CODVEICULO
                INNER JOIN locamobi.usuario u ON u.CODUSER = v.USUARIO_CODUSER
                WHERE v.USUARIO_CODUSER = @usuarioCod";

            using (var db = _connection.GetConnection())
            {
                return await db.QueryAsync<RatingEntity>(sql, new { usuarioCod });
            }
        }
    }
}
