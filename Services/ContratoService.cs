using API_Locamobi_CRUD_Repositories.Contracts.Service;
using API_Locamobi_CRUD_Repositories.DTO;
using API_Locamobi_CRUD_Repositories.Entity;
using API_Locamobi_CRUD_Repositories.Response;

namespace API_Locamobi_CRUD_Repositories.Services
{
    public class ContratoService : IContratoService
    {
        public Task<MessageResponse> Delete(int id)
        {
            throw new NotImplementedException();
        }

        public Task<ContratoGetAllResponse> GetAll()
        {
            throw new NotImplementedException();
        }

        public Task<ContratoEntity> GetById(int id)
        {
            throw new NotImplementedException();
        }

        public Task<MessageResponse> Post(ContratoInsertDTO contrato)
        {
            throw new NotImplementedException();
        }

        public Task<MessageResponse> Update(ContratoEntity contrato)
        {
            throw new NotImplementedException();
        }
    }
}