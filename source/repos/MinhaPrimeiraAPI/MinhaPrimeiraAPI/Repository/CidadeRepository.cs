using Crudzin.Contracts.Repository;
using Crudzin.DTO_;
using Crudzin.Entity;
using Crudzin.Infrastructure;
using Dapper;
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
        public async Task<IEnumerable<CidadeEntity>> GetAll()
        {
            Connection connection = new Connection();

            using (MySqlConnection con = connection.GetConnection())
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

            Connection connection = new Connection();

            using (MySqlConnection con = connection.GetConnection())
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

            Connection connection = new Connection();

            using (MySqlConnection con = connection.GetConnection())
            {
                await con.ExecuteAsync(sql, new {codigo });
            }

        }

        public async Task<CidadeEntity> GetById(int codigo)
        {
            Connection connection = new Connection();

            using (MySqlConnection con = connection.GetConnection())
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
            Connection connection = new Connection();

            string sql = @$"
                         UPDATE CIDADE 
                         SET NOMECID = @NOMECID,
                             UF = @UF
                         WHERE CODCID = @CODCID 
                         ";


            using (MySqlConnection con = connection.GetConnection())
            {
                await con.ExecuteAsync(sql, cidade);
            }
        }
    }
   
}



