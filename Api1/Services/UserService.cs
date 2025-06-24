using User.Contracts.Infrastructure;
using User.Contracts.Repository;
using User.Contracts.Service;
using User.DTO;
using User.Entity;
using User.Response;
using User.Response.User;

namespace User.Services
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
            var validatedUser = await ValidateUser(user.Email, user.Password);
            if (validatedUser == null)
                throw new Exception("Invalid credentials");
            string token = _authentication.GenerateToken(validatedUser);
           return new UserLoginResponse
           {
               User = validatedUser,
               Token = token
           };
        }

        public async Task<UserEntity> GetById(int id)
        {
            return await _repository.GetById(id);
        }

        public async Task<MessageResponse> Post(UserInsertDTO user)
        {
            user.Password = BCrypt.Net.BCrypt.HashPassword(user.Password);
            await _repository.Insert(user);
            return new MessageResponse
            {
                Message = "Usuário inserido com sucesso!"
            };
        }

        public async Task<MessageResponse> Update(UserEntity user)
        {
            await _repository.Update(user);
            return new MessageResponse
            {
                Message = "Usuário alterado com sucesso!"
            };
        }
        public async Task<UserEntity> ValidateUser(string email, string password)
        {
            var user = await _repository.GetByEmail(email);
            if (user == null)
                return null;
            
            bool senhaCorreta= BCrypt.Net.BCrypt.Verify(password, user.Password);
            return senhaCorreta ?  user : null;
        }

    }
}
