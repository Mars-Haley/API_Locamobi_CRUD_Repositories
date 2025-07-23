using Locamobi.DTO_;
using Locamobi.Entity;
using Locamobi.Response;
using Locamobi.Response.City;

namespace Locamobi.Contracts.Service
{
    public interface ICityService 
    {
        Task<CityGetAllResponse> GetAll();
        Task<CityEntity> GetById(int id);
        Task<MessageResponse> Post(CityInsertDTO city);
        Task<MessageResponse> Delete(int id);
        Task<MessageResponse> Update(CityEntity city);
    }
}
