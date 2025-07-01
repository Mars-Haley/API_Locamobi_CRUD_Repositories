using API_Locamobi_CRUD_Repositories.Contracts.Repository;
using API_Locamobi_CRUD_Repositories.DTO;
using API_Locamobi_CRUD_Repositories.Entity;
using API_Locamobi_CRUD_Repositories.Infrastructure;
using Dapper;
using MySql.Data.MySqlClient;

namespace API_Locamobi_CRUD_Repositories.Repository
{
    public class ContratoRepository : IContratoRepository
    {
        public async Task<IEnumerable<ContratoEntity>> GetAll()
        {
            Connection _connection = new Connection();

            using (MySqlConnection con = _connection.GetConnection())
            {
                string sql = $@"
                   SELECT CODCONTRATO ID AS {nameof(ContratoEntity.Id)},
                     DATAINICIO AS {nameof(ContratoEntity.DataInicio)},
                      DATAFIM AS {nameof(ContratoEntity.DataFim)},
                       PRECOBASE AS {nameof(ContratoEntity.PrecoBase)},
                         FROM contrato
                        ";
                IEnumerable<ContratoEntity> contratolist = await con.QueryAsync<ContratoEntity>(sql);
                return contratolist;
            }
        }

        public async Task Delete(int id)
        {
            Connection _connection = new Connection();

            string sql = "DELETE FROM contrato WHERE CODCONTRATO = @Id";

            await _connection.Execute(sql, new { id });
        }

        public Task DeleteById(int id)
        {
            throw new NotImplementedException();
        }


        public async Task<ContratoEntity> GetById(int id)
        {
            Connection _connection = new Connection();

            using (MySqlConnection con = _connection.GetConnection())
            {
                string sql = $@"
                   SELECT CODCONTRATO ID AS {nameof(ContratoEntity.Id)},
                     DATAINICIO AS {nameof(ContratoEntity.DataInicio)},
                      DATAFIM AS {nameof(ContratoEntity.DataFim)},
                       PRECOBASE AS {nameof(ContratoEntity.PrecoBase)},
                         FROM contrato
                        ";
                ContratoRepository _repository = new ContratoRepository();
                return await _repository.GetById(id);
            }
        }

        public async Task Insert(ContratoInsertDTO contrato)
        {
            Connection _connection = new Connection();

            using (MySqlConnection con = _connection.GetConnection())
            {
                string sql = $@"
                INSERT INTO  (DATAINICIO, DATAFIM, PRECOBASE, )
                             VALUE (@Nome, @ConsumoEnergetico, @HorasUsoDiario, @IdCategoria)
                ";
                await _connection.Execute(sql, contrato);
            }
        }

        public async Task Update(ContratoEntity contrato)
        {
            Connection _connection = new Connection();

            string sql = @"
                   UPDATE EQUIPAMENTOELETRICO
                     SET NOME = @Nome, CONSUMOENERGETICO = @ConsumoEnergetico, HORASUSODIARIO = @HorasUsoDiario
                        WHERE ID = @id
                        ";

            await _connection.Execute(sql, contrato);
        }
    }
}