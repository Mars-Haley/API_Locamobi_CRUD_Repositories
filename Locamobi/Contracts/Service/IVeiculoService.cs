using Locamobi_CRUD_Repositories.DTO;
using Locamobi_CRUD_Repositories.Entity;
using Locamobi.Response;
using Locamobi.Response.Veiculo;

namespace Locamobi.Contracts.Service
{
    public interface IVeiculoService
    {
        Task<MessageResponse> Delete(int codVeiculo);
        Task<VeiculoGetAllResponse> GetAll();
        Task<VeiculoEntity> GetByCodVeiculo(int codVeiculo);
        Task<MessageResponse> Post(VeiculoInsertDTO postVeiculo);
        Task<MessageResponse> Update(VeiculoEntity updateVeiculo);
       
    }
}
