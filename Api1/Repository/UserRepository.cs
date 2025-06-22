using Api1.Contracts.Infrastructure;
using Api1.Contracts.Repository;
using Api1.DTO;
using Api1.Entity;
using Dapper;
using Microsoft.EntityFrameworkCore;
using MySql.Data.MySqlClient;
using User.Infrastructure;

namespace Api1.Repository
{
    public class UserRepository : IUserRepository
    {
        private IConnection _connection;
        private AppDbContext _dbContext;

        public UserRepository(IConnection connection, AppDbContext dbContext)
        {
            _connection = connection;
            _dbContext = dbContext;
        }

        public async Task<IEnumerable<string>> GetUserNameInCity3()
        {
            var names = await (from u in _dbContext.Users
                    where u.CityId == 3
                        select u.Name).ToListAsync();
            return names;
        }

        public async Task<IEnumerable<UserEntity>> GetUsersStartWithA()
        {
            var allUsers = await GetAll();
            var filtered = allUsers.Where(u => u.Name.StartsWith("A"));
            return filtered;
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
                                SENHA AS {nameof(UserEntity.Password)},
                                NUMERO AS {nameof(UserEntity.PhoneNumber)},
                                ENDERECO AS {nameof(UserEntity.Address)},
                                CIDADE_CODCID AS {nameof(UserEntity.CityId)}
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
                                SENHA AS {nameof(UserEntity.Password)},
                                NUMERO AS {nameof(UserEntity.PhoneNumber)},
                                ENDERECO AS {nameof(UserEntity.Address)},
                                CIDADE_CODCID AS {nameof(UserEntity.CityId)}
                                FROM USUARIO 
                                WHERE CODUSER = @Id";
                UserEntity user = await con.QueryFirstAsync<UserEntity>(sql, new { id });
                return user;
            }

        }
        public async Task<UserEntity> GetByEmail(string email)
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
            string sql = $@"INSERT INTO USUARIO (NOME,EMAIL,SENHA,NUMERO,ENDERECO,CIDADE_CODCID)
                            VALUES(@Name,@Email,@Password,@PhoneNumber,@Address,@CityId)";
            await _connection.Execute(sql, user);
        }


        public async Task Update(UserEntity user)
        {
            string sql = $@"UPDATE USUARIO 
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
