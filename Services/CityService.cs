using Locamobi.Contracts.Repository;
using Locamobi.DTO_;
using Locamobi.Contracts.Service;
using Locamobi.Entity;
using Locamobi.Response;
using Locamobi.Response.City;

namespace Locamobi.Services
{
    public class CityService : ICityService
    {

        private ICityRepository _repository;

        public CityService(ICityRepository repository) 
        { 
            _repository = repository;
        }


        public async Task<MessageResponse> Delete(int id)
        {
            await _repository.Delete(id);
            return new MessageResponse
            {
                Message = "Cidade excluida com sucesso"
            };
        }

        public async Task<CityGetAllResponse> GetAll()
        {
            return new CityGetAllResponse
            {
                Data = await _repository.GetAll()
            };
        }
        public async Task<CityEntity> GetById(int id)
        {
            return await _repository.GetById(id);
        }

        public async Task<MessageResponse> Post(CityInsertDTO city)
        {
            await _repository.Insert(city);
            return new MessageResponse
            {
                Message = "Mecanico inserido com sucesso!"
            };
        }

        public async Task<MessageResponse> Update(CityEntity city)
        {
            await _repository.Update(city);
            return new MessageResponse
            {
                Message = "Cidade alterada com sucesso!"
            };
        }
    }

    
}
