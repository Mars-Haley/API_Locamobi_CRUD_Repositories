using Locamobi.DTO_;
using Locamobi.Entity;

namespace Locamobi.Contracts.Repository
{
    public interface ICityRepository
    {
        Task<IEnumerable<CityEntity>> GetAll();
        Task<CityEntity> GetById(int id);
        Task Insert(CityInsertDTO city);
        Task Delete(int id);
        Task Update(CityEntity city);
    }
}
