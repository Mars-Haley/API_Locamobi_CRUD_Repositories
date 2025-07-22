using Locamobi_CRUD_Repositories.DTO;
using Locamobi_CRUD_Repositories.Entity;
using Locamobi.Response;
using Locamobi.Response.Veiculo;

namespace Locamobi.Contracts.Service
{
    public interface IVehicleService
    {
        Task<MessageResponse> Delete(int codVeiculo);
        Task<VeiculoGetAllResponse> GetAll();
        Task<VehicleEntity> GetByCodVeiculo(int codVeiculo);
        Task<MessageResponse> Post(VehicleInsertDTO postVehicle);
        Task<MessageResponse> Update(VehicleEntity updateVehicle);
       
    }
}
