using System.Text.RegularExpressions;
using Locamobi.Contracts.Repository;
using Locamobi.DTO;
using Locamobi.Entity;
using Locamobi.Repository;
using Locamobi.Contracts.Service;
using Locamobi.Response;
using Locamobi.Response.Veiculo;

namespace Locamobi.Services
{

    public class VehicleService : IVehicleService
    {

        private IVehicleRepository _vehicleRepository;

        public VehicleService(IVehicleRepository vehicleRepository)
        {
            _vehicleRepository = vehicleRepository;
        }

        public async Task<MessageResponse> Delete(int id)//verificar esse id
        {
            await _vehicleRepository.Delete(id);
            return new MessageResponse
            {
                Message = "Veiculo deletado com sucesso."
            };

        }

        public async Task<VeiculoGetAllResponse> GetAll()
        {
            return new VeiculoGetAllResponse
            {
                Data = await _vehicleRepository.GetAll()
            };

        }


        public async Task<VehicleEntity> GetById(int id)
        {
            return await _vehicleRepository.GetById(id);
        }

        public async Task<MessageResponse> Post(VehicleInsertDTO vehicle)
        {
            await _vehicleRepository.Insert(vehicle);
            return new MessageResponse
            {
                Message = "Veiculo cadastrado com sucesso."
            };
        }

        public async Task<MessageResponse> Update(VehicleEntity vehicle)
        {
            await _vehicleRepository.Update(vehicle);
            return new MessageResponse
            {
                Message = "Veiculo atualizado com sucesso."
            };


        }
    }
}
