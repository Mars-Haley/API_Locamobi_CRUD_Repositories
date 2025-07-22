using Locamobi.DTO;
using Locamobi.Entity;

namespace Locamobi.Contracts.Repository
{
    public interface IUserRepository
    {
        Task<IEnumerable<UserEntity>> GetAll();
        Task<UserEntity> GetById(int id);
        Task<UserEntity> Login(UserLoginDTO user);
        Task<UserEntity> GetByEmail(string email);
        Task Insert(UserInsertDTO user);
        Task Delete(int id);
        Task Update(UserEntity user);
        Task<bool> SaveRecuperationToken(string email, string token, DateTime expires);
        Task<bool> UpdatePasswordByToken(string token, string newPassword);
    }
}
