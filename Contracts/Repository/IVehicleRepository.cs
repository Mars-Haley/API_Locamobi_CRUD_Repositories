using Locamobi_CRUD_Repositories.DTO;
using Locamobi_CRUD_Repositories.Entity;
using Locamobi.Response;

namespace Locamobi_CRUD_Repositories.Contracts.Repository
{
    public interface IVehicleRepository
    {
        Task<IEnumerable<VehicleEntity>> GetAll();

        Task Insert(VehicleInsertDTO vehicleInsert);

        Task Update(VehicleEntity vehicleUpdate);

        Task<VehicleEntity> GetByCodVeiculo(int codVeiculo);

        Task Delete(int codVeiculo);
    }
}
