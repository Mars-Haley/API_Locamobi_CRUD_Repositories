using Api1.Contracts.Infrastructure;
using Api1.Contracts.Repository;
using Api1.DTO;
using Api1.Entity;
using Dapper;
using MySql.Data.MySqlClient;

namespace Api1.Repository
{
    public class UserRepository : IUserRepository
    {
        private IConnection _connection;

        public UserRepository(IConnection connection)
        {
            _connection = connection;
        }

        public async Task Delete(int id)
        {
            string sql = @$"DELETE FROM usuario 
                            WHERE CODUSER = @Id";
            await _connection.Execute(sql, new { id });
        }

        public async Task<IEnumerable<UserEntity>> GetAll()
        {
            using (MySqlConnection con = _connection.GetConnection())
            {
                string sql = $@"SELECT CODUSER AS {nameof(UserEntity.Id)},
                                NOME AS {nameof(UserEntity.Name)},
                                EMAIL AS {nameof(UserEntity.Email)},
                                SENHA AS {nameof(UserEntity.Password)},
                                NUMERO AS {nameof(UserEntity.PhoneNumber)},
                                ENDERECO AS {nameof(UserEntity.Address)},
                                CIDADE_CODCID AS {nameof(UserEntity.CityId)}
                                FROM usuario";
                IEnumerable<UserEntity> userList = await con.QueryAsync<UserEntity>(sql);

                return userList;
            }
        }

        public async Task<UserEntity> GetById(int id)
        {
            using (MySqlConnection con = _connection.GetConnection())
            {
                string sql = $@"SELECT CODUSER AS {nameof(UserEntity.Id)},
                                NOME AS {nameof(UserEntity.Name)},
                                EMAIL AS {nameof(UserEntity.Email)},
                                SENHA AS {nameof(UserEntity.Password)},
                                NUMERO AS {nameof(UserEntity.PhoneNumber)},
                                ENDERECO AS {nameof(UserEntity.Address)},
                                CIDADE_CODCID AS {nameof(UserEntity.CityId)}
                                FROM usuario
                                WHERE CODUSER = @Id";
                UserEntity user = await con.QueryFirstAsync<UserEntity>(sql, new { id });
                return user;
            }

        }

        public async Task Insert(UserInsertDTO user)
        {
            string sql = $@"INSERT INTO usuario (NOME,EMAIL,SENHA,NUMERO,ENDERECO,CIDADE_CODCID)
                            VALUES(@Name,@Email,@Password,@PhoneNumber,@Address,@CityId)";
            await _connection.Execute(sql, user);
        }


        public async Task Update(UserEntity user)
        {
            string sql = $@"UPDATE usuario 
                            SET NOME = @Name,
                            EMAIL = @Email,
                            ENDERECO = @Address,
                            NUMERO = @PhoneNumber,
                            SENHA = @Password
                            WHERE CODUSER = @Id";
            await _connection.Execute(sql, user);
        }
    }
}
