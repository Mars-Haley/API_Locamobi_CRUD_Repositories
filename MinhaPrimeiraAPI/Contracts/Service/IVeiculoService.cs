using Locamobi_CRUD_Repositories.DTO;
using Locamobi_CRUD_Repositories.Entity;
using MinhaPrimeiraAPI.Response;
using MinhaPrimeiraAPI.Response.Veiculo;

namespace MinhaPrimeiraAPI.Contracts.Service
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
