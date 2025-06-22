using Api1.DTO;
using Api1.Entity;

namespace Api1.Contracts.Repository
{
    public interface IUserRepository
    {
        Task<IEnumerable<UserEntity>> GetAll();
        Task<IEnumerable<string>> GetUserNameInCity3();
        Task<IEnumerable<UserEntity>> GetUsersStartWithA(); 
        Task<UserEntity> GetById(int id);
        Task<UserEntity> GetByEmail(string email);
        Task Insert(UserInsertDTO user);
        Task Delete(int id);
        Task Update(UserEntity user);
    }
}
