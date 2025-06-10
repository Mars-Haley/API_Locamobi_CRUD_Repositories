using API_Locamobi_CRUD_Repositories.DTO;
using API_Locamobi_CRUD_Repositories.Entity;
using API_Locamobi_CRUD_Repositories.Response;
using API_Locamobi_CRUD_Repositories.Response._____;

namespace API_Locamobi_CRUD_Repositories.Contracts.Service
{
    public interface I_____Service
    {
        Task<MessageResponse> Delete(int id);

        Task<_____GetAllResponse> GetAll();

        Task<_____Entity> GetById(int id);

        Task<MessageResponse> Post(_____InsertDTO _____);

        Task<MessageResponse> Update(_____Entity _____);
    }
}