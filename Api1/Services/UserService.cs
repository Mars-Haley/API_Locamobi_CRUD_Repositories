using Api1.Contracts.Repository;
using Api1.Contracts.Service;
using Api1.DTO;
using Api1.Entity;
using Api1.Response;
using Api1.Response.User;

namespace Api1.Services
{
    public class UserService : IUserService
    {

        private IUserRepository _repository;

        public UserService(IUserRepository repository)
        {
            _repository = repository;
        }

        public async Task<MessageResponse> Delete(int id)
        {
            await _repository.Delete(id);
            return new MessageResponse
            {
                Message = "Usuário excluído com sucesso!"
            };
        }
        public async Task<UserGetAllResponse> GetUsersInCity3()
        {
            return new UserGetAllResponse
            {
                Names = await _repository.GetUserNameInCity3()
            };
        }
        public async Task<UserGetAllResponse> GetUsersStartWithA()
        {
            return new UserGetAllResponse
            {
                Data = await _repository.GetUsersStartWithA()
            };
        }

        public async Task<UserGetAllResponse> GetAll()
        {
            return new UserGetAllResponse
            {
                Data = await _repository.GetAll()
            };
        }

        public async Task<UserEntity> GetById(int id)
        {
            return await _repository.GetById(id);
        }

        public async Task<MessageResponse> Post(UserInsertDTO user)
        {
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
            return user;
        }

    }
}
