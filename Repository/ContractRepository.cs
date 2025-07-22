using Dapper;
using Locamobi.Contracts.Repository;
using Locamobi.DTO;
using Locamobi.Entity;
using Locamobi.Infrastructure;
using MySql.Data.MySqlClient;

namespace Locamobi.Repository
{
    public class ContractRepository : IContractRepository
    {
        public async Task<IEnumerable<ContractEntity>> GetAll()
        {
            Connection _connection = new Connection();

            using (MySqlConnection con = _connection.GetConnection())
            {
                string sql = $@"
                   SELECT CODCONTRATO AS {nameof(ContractEntity.Id)},
                     DATAINICIO AS {nameof(ContractEntity.StartDate)},
                      DATAFIM AS {nameof(ContractEntity.EndDate)},
                       PRECOBASE AS {nameof(ContractEntity.BasePrice)}
                         FROM CONTRATO
                        ";
                IEnumerable<ContractEntity> contratolist = await con.QueryAsync<ContractEntity>(sql);
                return contratolist;
            }
        }

        public async Task Delete(int id)
        {
            Connection _connection = new Connection();

            string sql = "DELETE FROM CONTRATO WHERE CODCONTRATO = @Id";

            await _connection.Execute(sql, new { id });
        }


        public async Task<ContractEntity> GetById(int id)
        {
            Connection _connection = new Connection();

            using (MySqlConnection con = _connection.GetConnection())
            {
                string sql = $@"
                   SELECT CODCONTRATO AS {nameof(ContractEntity.Id)},
                     DATAINICIO AS {nameof(ContractEntity.StartDate)},
                      DATAFIM AS {nameof(ContractEntity.EndDate)},
                       PRECOBASE AS {nameof(ContractEntity.BasePrice)},
                         FROM CONTRATO
                        ";
                ContractRepository _repository = new ContractRepository();
                return await _repository.GetById(id);
            }
        }

        public async Task Insert(ContractInsertDTO contrato)
        {
            Connection _connection = new Connection();

            using (MySqlConnection con = _connection.GetConnection())
            {
                string sql = $@"
                INSERT INTO CONTRATO (DATAINICIO, DATAFIM, PRECOBASE)
                             VALUES (@StartDate, @EndDate, @BasePrice)
                ";
                await _connection.Execute(sql, contrato);
            }
        }

        public async Task Update(ContractEntity contract)
        {
            Connection _connection = new Connection();

            string sql = @"
                   UPDATE CONTRATO
                     SET DATAINICIO = @StartDate,
                     DATAFIM = @EndDate,
                     PRECOBASE = @BasePrice
                        WHERE CODCONTRATO = @Id
                        ";

            await _connection.Execute(sql, contract);
        }
    }
}