using Dapper;
using MySql.Data.MySqlClient;
using Locamobi.Contracts.Infrastructure;
using Locamobi.Contracts.Repository;
using Locamobi.DTO;
using Locamobi.Entity;

namespace Locamobi.Repository
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
            string sql = @$"DELETE FROM USUARIO 
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
                                NUMERO AS {nameof(UserEntity.PhoneNumber)},
                                ENDERECO AS {nameof(UserEntity.Address)},
                                CIDADE_CODCID AS {nameof(UserEntity.CityId)},
                                GENERO AS  {nameof(UserEntity.GenderText)},
                                DATA_NASCIMENTO AS {nameof(UserEntity.Birthday)}
                                FROM USUARIO";
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
                                NUMERO AS {nameof(UserEntity.PhoneNumber)},
                                ENDERECO AS {nameof(UserEntity.Address)},
                                CIDADE_CODCID AS {nameof(UserEntity.CityId)},
                                GENERO AS {nameof(UserEntity.GenderText)},
                                DATA_NASCIMENTO AS {nameof(UserEntity.Birthday)}
                                FROM USUARIO 
                                WHERE CODUSER = @Id";
                UserEntity user = await con.QueryFirstAsync<UserEntity>(sql, new { id });
                return user;
            }

        }

       
        public async Task<UserEntity> Login(UserLoginDTO user)
        {
            using (MySqlConnection con = _connection.GetConnection())
            {
                string sql = $@"SELECT CODUSER AS {nameof(UserEntity.Id)},
                                NOME AS  {nameof(UserEntity.Name)},
                                EMAIL AS {nameof(UserEntity.Email)}
                                FROM USUARIO
                                WHERE EMAIL = @Email AND SENHA = @Password";
                return await con.QueryFirstAsync<UserEntity>(sql, user);
            } 
        }
        

        public async Task<UserEntity> GetByEmail(string email)
        {
            using (MySqlConnection con = _connection.GetConnection())
            {
                string sql = $@"SELECT CODUSER AS {nameof(UserEntity.Id)},
                                NOME AS {nameof(UserEntity.Name)},
                                EMAIL AS {nameof(UserEntity.Email)},
                                NUMERO AS {nameof(UserEntity.PhoneNumber)},
                                ENDERECO AS {nameof(UserEntity.Address)},
                                CIDADE_CODCID AS {nameof(UserEntity.CityId)},
                                GENERO AS {nameof(UserEntity.GenderText)},
                                DATA_NASCIMENTO AS {nameof(UserEntity.Birthday)}
                                FROM USUARIO
                                WHERE EMAIL = @Email";
                UserEntity? user = await con.QueryFirstOrDefaultAsync<UserEntity>(sql, new { email });
                if (user == null)
                    throw new Exception("User not found");
                return user;
            }
        }

        public async Task Insert(UserInsertDTO user)
        {
            string sql = $@"INSERT INTO USUARIO (NOME,EMAIL,CPF,SENHA,NUMERO,ENDERECO,CIDADE_CODCID,GENERO,DATA_NASCIMENTO)
                            VALUES(@Name,@Email,@Cpf,@Password,@PhoneNumber,@Address,@CityId,@Gender,@Birthday)";
            await _connection.Execute(sql, user);
        }


        public async Task Update(UserEntity user)
        {
            string sql = $@"UPDATE USUARIO 
                            SET NOME = @Name,
                            EMAIL = @Email,
                            ENDERECO = @Address,
                            NUMERO = @PhoneNumber,
                            GENERO = @Gender
                            WHERE CODUSER = @Id";
            await _connection.Execute(sql, user);
        }

        public async Task<bool> SaveRecuperationToken(string email, string token, DateTime expires)
        {
            using (MySqlConnection con = _connection.GetConnection())
            {
                var query = @"UPDATE USUARIO SET TOKEN_RECUPERACAO = @Token, TOKEN_EXPIRA = @Expira WHERE email = @Email";
                var result = await con.ExecuteAsync(query, new { Email = email, Token = token, Expira = expires });
                return result > 0;
            }
        }

        public async Task<bool> UpdatePasswordByToken(string token, string newPassword)
        {
            using (MySqlConnection con = _connection.GetConnection())
            {
                var query = @"UPDATE USUARIO SET SENHA = @Senha, TOKEN_RECUPERACAO = NULL, TOKEN_EXPIRA = NULL 
                  WHERE token_recuperacao = @Token AND token_expira > NOW()";
                var result = await con.ExecuteAsync(query, new { Token = token, Senha = newPassword });

                return result > 0;
            }
        }
    }
}
