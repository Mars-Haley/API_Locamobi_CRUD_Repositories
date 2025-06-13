using Crudzin.Contracts.Repository;
using Crudzin.DTO_;
using Crudzin.Entity;
using Crudzin.Infrastructure;
using Dapper;
using MinhaPrimeiraAPI.Contracts.Infrastructure;
using MySql.Data.MySqlClient;
using Org.BouncyCastle.Crypto.Digests;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;

namespace Crudzin.Repository
{
    public class CidadeRepository : ICidadeRepository
    {

        private IConnection _connection;

        public CidadeRepository(IConnection connection)
        {
            _connection = connection;
        }

        public async Task<IEnumerable<CidadeEntity>> GetAll()
        {
            using (MySqlConnection con = _connection.GetConnection())
            {
                string sql = @$"
                        SELECT CODCID AS {nameof(CidadeEntity.CODCID)},
                            NOMECID AS {nameof(CidadeEntity.NOMECID)},
                            UF AS {nameof(CidadeEntity.UF)} 
                        FROM cidade
                    ";

                IEnumerable<CidadeEntity> cityList = await con.QueryAsync<CidadeEntity>(sql);
                return cityList;

            }
        }

        public async Task Insert(CidadeInsertDTO cidade)
        {
            string sql = $@"
                       INSERT INTO CIDADE(NOMECID, UF)
                       VALUE(@NOMECID, @UF)";

            using (MySqlConnection con = _connection.GetConnection())
            {
                await con.ExecuteAsync(sql, cidade);

            }
        }

        public async Task Delete(int codigo)
        {
            string sql = @$"
                            DELETE FROM CIDADE 
                            WHERE CODCID = @codigo
                            ";

            using (MySqlConnection con = _connection.GetConnection())
            {
                await con.ExecuteAsync(sql, new {codigo });
            }

        }

        public async Task<CidadeEntity> GetById(int codigo)
        {
            using (MySqlConnection con = _connection.GetConnection())
            {
                string sql = @$"
                             SELECT CODCID AS {nameof(CidadeEntity.CODCID)},
                            NOMECID AS {nameof(CidadeEntity.NOMECID)},
                            UF AS {nameof(CidadeEntity.UF)} 
                            FROM CIDADE
                            WHERE CODCID = @codigo
                            ";

                CidadeEntity cidade = await con.QueryFirstAsync<CidadeEntity>(sql, new { codigo });
                return cidade;
            }
        }

        public async Task Update(CidadeEntity cidade)
        {
            string sql = @$"
                         UPDATE CIDADE 
                         SET NOMECID = @NOMECID,
                             UF = @UF
                         WHERE CODCID = @CODCID 
                         ";


            using (MySqlConnection con = _connection.GetConnection())
            {
                await con.ExecuteAsync(sql, cidade);
            }
        }
    }
   
}



