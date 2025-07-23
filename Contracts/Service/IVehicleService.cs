using Locamobi.DTO;
using Locamobi.Entity;
using Locamobi.Response;
using Locamobi.Response.Veiculo;

namespace Locamobi.Contracts.Service
{
    public interface IVehicleService
    {
        Task<MessageResponse> Delete(int id);
        Task<VeiculoGetAllResponse> GetAll();
        Task<VehicleEntity> GetById(int id);
        Task<MessageResponse> Post(VehicleInsertDTO postVehicle);
        Task<MessageResponse> Update(VehicleEntity updateVehicle);
       
    }
}
