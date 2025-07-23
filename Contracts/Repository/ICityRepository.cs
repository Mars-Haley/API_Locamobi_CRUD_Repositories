using Crudzin.DTO_;
using Locamobi.Entity;

namespace Crudzin.Contracts.Repository
{
    public interface ICityRepository
    {
        Task<IEnumerable<CityEntity>> GetAll();
        Task<CityEntity> GetById(int codigo);
        Task Insert(CityInsertDTO city);
        Task Delete(int codigo);
        Task Update(CityEntity city);
    }
}
