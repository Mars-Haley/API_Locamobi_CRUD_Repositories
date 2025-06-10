using Dapper;
using Locamobi_CRUD_Repositories.Contracts.Repository;
using Locamobi_CRUD_Repositories.DTO;
using Locamobi_CRUD_Repositories.Entity;
using MeuPrimeiroCrud.Infrastructure;
using MySql.Data.MySqlClient;

namespace Locamobi_CRUD_Repositories.Repository
{
    public class VeiculoRepository : IVeiculoRepository
    {
        public async Task <IEnumerable<VeiculoEntity>> GetAll() 
        {
            Connection _connection = new Connection();
            using (MySqlConnection con = _connection.GetConnection())
            {
                string sql = $@"
                        SELECT CODVEICULO AS {nameof(VeiculoEntity.CodVeiculo)},
                         MODELO AS {nameof(VeiculoEntity.Modelo)},
                            MARCA AS {nameof(VeiculoEntity.Marca)},
                              ANO AS {nameof(VeiculoEntity.Ano)},
                                PLACA AS {nameof(VeiculoEntity.Placa)},
                                  COR AS {nameof(VeiculoEntity.Cor)},
                                    CIDADE_CODCID AS {nameof(VeiculoEntity.Cidade_CodCid)},
                                      CLASSIFIC AS {nameof(VeiculoEntity.Classific)},
                                        TIPO AS {nameof(VeiculoEntity.Tipo)},
                                          USUARIO_CODUSER {nameof(VeiculoEntity.Usuario_CodUser)}
                        FROM veiculo";

                IEnumerable<VeiculoEntity> veiculoList = await con.QueryAsync<VeiculoEntity>(sql);
                return veiculoList;
            }


        }



        public async Task Delete(int codVeiculo)
        {
            Connection _connection = new Connection();
            string sql = "DELETE FROM veiculo WHERE CODVEICULO = @codVeiculo";
            await _connection.Execute(sql, new {codVeiculo});

        }

        public async Task<VeiculoEntity> GetByCodVeiculo(int codVeiculo) 
        {
            Connection _connection = new Connection();
            using (MySqlConnection con = _connection.GetConnection())
            {
                string sql =$@"
                        SELECT CODVEICULO AS {nameof(VeiculoEntity.CodVeiculo)},
                         MODELO AS {nameof(VeiculoEntity.Modelo)},
                            MARCA AS {nameof(VeiculoEntity.Marca)},
                              ANO AS {nameof(VeiculoEntity.Ano)},
                                PLACA AS {nameof(VeiculoEntity.Placa)},
                                  COR AS {nameof(VeiculoEntity.Cor)},
                                    CIDADE_CODCID AS {nameof(VeiculoEntity.Cidade_CodCid)},
                                      CLASSIFIC AS {nameof(VeiculoEntity.Classific)},
                                        TIPO AS {nameof(VeiculoEntity.Tipo)}
                            FROM veiculo
                            WHERE CODVEICULO = @CodVeiculo";//Adionar o USUARIO_CODUSER {nameof(VeiculoEntity.USUARIO_CODUSER)} apos merge.
                VeiculoEntity veiculoEntity = await con.QueryFirstAsync<VeiculoEntity>(sql, new {codVeiculo});
                return veiculoEntity;
        
            }


        }

        public async Task Insert(VeiculoInsertDTO veiculoInsert)
        {
            Connection _connection = new Connection();
            string sql = $@"
                            INSERT INTO veiculo (MODELO, MARCA, ANO, PLACA,
                                COR, CIDADE_CODCID, CLASSIFIC, TIPO, USUARIO_CODUSER) 
                                    VALUES  (@Modelo, @Marca, @Ano, @Placa,
                                        @Cor, @Cidade_CodCid, @Classific, @Tipo, @Usuario_CodUser)";

            await _connection.Execute(sql, veiculoInsert);
        }

        public async Task Update(VeiculoEntity veiculoUpdate)
        {
            Connection _connection = new Connection();

            string sql = $@"
                UPDATE veiculo 
                SET MODELO = @Modelo, 
                    MARCA = @Marca,
                      ANO = @Ano,
                        PLACA = @Placa,
                          COR = @Cor,
                            CIDADE_CODCID = @Cidade_CodCid,
                              CLASSIFIC = @Classific,
                                TIPO = @Tipo                     
                 WHERE CODVEICULO = @CodVeiculo ";//@Usuario_CodUser vai ser inserido após merge.

            await _connection.Execute(sql, veiculoUpdate);
        }
    }
}
