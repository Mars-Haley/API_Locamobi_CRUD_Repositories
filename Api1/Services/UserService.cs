using Locamobi.Contracts.Infrastructure;
using Locamobi.Contracts.Repository;
using Locamobi.Contracts.Service;
using Locamobi.DTO;
using Locamobi.Entity;
using Locamobi.Infrastructure;
using Locamobi.Response;
using Locamobi.Response.User;

namespace Locamobi.Services
{
    public class UserService : IUserService
    {

        private IUserRepository _repository;
        private IAuthentication _authentication;

        public UserService(IUserRepository repository, IAuthentication authentication)
        {
            _repository = repository;
            _authentication = authentication;
        }

        public async Task<MessageResponse> Delete(int id)
        {
            await _repository.Delete(id);
            return new MessageResponse
            {
                Message = "Usuário excluído com sucesso!"
            };
        }

        public async Task<UserGetAllResponse> GetAll()
        {
            return new UserGetAllResponse
            {
                Data = await _repository.GetAll()
            };
        }

        public async Task<UserLoginResponse> Login(UserLoginDTO user)
        {
            user.Password = Cryptography.Encrypt(user.Password);
            UserEntity newUser = await _repository.Login(user);
            string token = _authentication.GenerateToken(newUser);
           return new UserLoginResponse
           {
               User = newUser,
               Token = token
           };
        }

        public async Task<UserEntity> GetById(int id)
        {
            return await _repository.GetById(id);
        }

        public async Task<MessageResponse> Post(UserInsertDTO user)
        {
           user.Password = Cryptography.Encrypt(user.Password); 
            await _repository.Insert(user);
            return new MessageResponse
            {
                Message = "Usuário inserido com sucesso!"
            };
        }

        public async Task<MessageResponse> Update(UserEntity user)
       {
           user.Password = Cryptography.Encrypt(user.Password);
            await _repository.Update(user);
            return new MessageResponse
            {
                Message = "Usuário alterado com sucesso!"
            };
        }
        public async Task<UserEntity> ValidateUser(string email, string password)
        {
            var user = await _repository.GetByEmail(email);
            return user;
        }

        public async Task<MessageResponse> UpdatePassword(UserEntity user, string token, string newPassword)
        {
            user.Password = Cryptography.Encrypt(user.Password);
            await _repository.UpdatePasswordByToken(token,newPassword);
            return new MessageResponse
            {
                Message = "Senha alterada com sucesso!"
            };
        }

    }
}
