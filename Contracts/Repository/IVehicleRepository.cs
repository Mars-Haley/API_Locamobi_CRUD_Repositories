using Locamobi.DTO;
using Locamobi.Entity;

namespace Locamobi.Contracts.Repository
{
    public interface IVehicleRepository
    {
        Task<IEnumerable<VehicleEntity>> GetAll();

        Task Insert(VehicleInsertDTO vehicleInsert);

        Task Update(VehicleEntity vehicleUpdate);

        Task<VehicleEntity> GetById(int id);

        Task Delete(int id);
    }
}
