using Api1.DTO;
using Api1.Entity;
using Api1.Response;
using Api1.Response.User;

namespace Api1.Contracts.Service
{
    public interface IUserService
    {
        Task<MessageResponse> Delete(int id);
        Task<UserGetAllResponse> GetAll();
        Task<UserGetAllResponse> GetUsersStartWithA();
        Task<UserGetAllResponse> GetUsersInCity3();
        Task<UserEntity> GetById(int id);
        Task<UserEntity> ValidateUser(string email, string password);
        Task<MessageResponse> Post(UserInsertDTO user);
        Task<MessageResponse> Update(UserEntity user);
    }
}
