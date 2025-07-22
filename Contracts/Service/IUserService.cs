using Locamobi.DTO;
using Locamobi.Entity;
using Locamobi.Response;
using Locamobi.Response.User;

namespace Locamobi.Contracts.Service
{
    public interface IUserService
    {
        Task<MessageResponse> Delete(int id);
        Task<UserGetAllResponse> GetAll();
        Task<UserLoginResponse> Login(UserLoginDTO user);
        Task<UserEntity> GetById(int id);
        Task<UserEntity> ValidateUser(string email, string password);
        Task<MessageResponse> Post(UserInsertDTO user);
        Task<MessageResponse> Update(UserEntity user);
    }
}
