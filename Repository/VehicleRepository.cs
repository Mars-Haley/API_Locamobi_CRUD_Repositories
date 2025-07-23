using Dapper;
using Locamobi.Contracts.Repository;
using Locamobi.DTO;
using Locamobi.Entity;
using Locamobi.Contracts.Infrastructure;
using MySql.Data.MySqlClient;

namespace Locamobi.Repository
{

    public class VehicleRepository : IVehicleRepository
    {

        private IConnection _connection;

        public VehicleRepository(IConnection connection)
        {
            _connection = connection;
        }

        public async Task <IEnumerable<VehicleEntity>> GetAll() 
        {
            using (MySqlConnection con = _connection.GetConnection())
            {
                string sql = $@"
                        SELECT CODVEICULO AS {nameof(VehicleEntity.Id)},
                         MODELO AS {nameof(VehicleEntity.Modelo)},
                            MARCA AS {nameof(VehicleEntity.Marca)},
                              ANO AS {nameof(VehicleEntity.Ano)},
                                PLACA AS {nameof(VehicleEntity.Placa)},
                                  COR AS {nameof(VehicleEntity.Cor)},
                                    CIDADE_CODCID AS {nameof(VehicleEntity.Cidade_CodCid)},
                                      CLASSIFIC AS {nameof(VehicleEntity.Classific)},
                                        TIPO AS {nameof(VehicleEntity.Tipo)},
                                          USUARIO_CODUSER {nameof(VehicleEntity.Usuario_CodUser)}
                        FROM veiculo";

                IEnumerable<VehicleEntity> veiculoList = await con.QueryAsync<VehicleEntity>(sql);
                return veiculoList;
            }
        }

        public async Task Delete(int id)
        {
            string sql = "DELETE FROM veiculo WHERE CODVEICULO = @Id";
            await _connection.Execute(sql, new {id});

        }

        public async Task<VehicleEntity> GetById(int id) 
        {
            using (MySqlConnection con = _connection.GetConnection())
            {
                string sql =$@"
                        SELECT CODVEICULO AS {nameof(VehicleEntity.Id)},
                         MODELO AS {nameof(VehicleEntity.Modelo)},
                            MARCA AS {nameof(VehicleEntity.Marca)},
                              ANO AS {nameof(VehicleEntity.Ano)},
                                PLACA AS {nameof(VehicleEntity.Placa)},
                                  COR AS {nameof(VehicleEntity.Cor)},
                                    CIDADE_CODCID AS {nameof(VehicleEntity.Cidade_CodCid)},
                                      CLASSIFIC AS {nameof(VehicleEntity.Classific)},
                                        TIPO AS {nameof(VehicleEntity.Tipo)}
                            FROM veiculo
                            WHERE CODVEICULO = @Id";//Adionar o USUARIO_CODUSER {nameof(VeiculoEntity.USUARIO_CODUSER)} apos merge.
                VehicleEntity vehicleEntity = await con.QueryFirstAsync<VehicleEntity>(sql, new {id});
                return vehicleEntity;
        
            }

        }

        public async Task Insert(VehicleInsertDTO vehicleInsert)
        {
            string sql = $@"
                            INSERT INTO veiculo (MODELO, MARCA, ANO, PLACA,
                                COR, CIDADE_CODCID, CLASSIFIC, TIPO, USUARIO_CODUSER) 
                                    VALUES  (@Modelo, @Marca, @Ano, @Placa,
                                        @Cor, @Cidade_CodCid, @Classific, @Tipo, @Usuario_CodUser)";

            await _connection.Execute(sql, vehicleInsert);
        }

        public async Task Update(VehicleEntity vehicleUpdate)
        {
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
                 WHERE CODVEICULO = @Id ";//@Usuario_CodUser vai ser inserido após merge.

            await _connection.Execute(sql, vehicleUpdate);
        }

    }
}
