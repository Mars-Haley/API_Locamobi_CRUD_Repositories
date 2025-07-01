using API_Locamobi_CRUD_Repositories.DTO;
using API_Locamobi_CRUD_Repositories.Entity;
using API_Locamobi_CRUD_Repositories.Response;

namespace API_Locamobi_CRUD_Repositories.Contracts.Service
{
    public interface IContratoService
    {
        Task<MessageResponse> Delete(int id);

        Task<ContratoGetAllResponse> GetAll();

        Task<ContratoEntity> GetById(int id);

        Task<MessageResponse> Post(ContratoInsertDTO contrato);

        Task<MessageResponse> Update(ContratoEntity contrato);
    }
}