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
        Task<UserEntity> GetById(int id);
        Task<MessageResponse> Post(UserInsertDTO user);
    }
}
