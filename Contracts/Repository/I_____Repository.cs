using API_Locamobi_CRUD_Repositories.DTO;
using API_Locamobi_CRUD_Repositories.Entity;

namespace API_Locamobi_CRUD_Repositories.Contracts.Repository
{
    public interface I_____Repository
    {
        Task<IEnumerable<_____Entity>> GetAll();

        Task Insert(_____InsertDTO new_____);

        Task Update(_____Entity _____);

        Task<_____Entity> GetById(int id);

        Task DeleteById(int id);

        Task Delete(int id);
    }
}