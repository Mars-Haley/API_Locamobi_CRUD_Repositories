using Crudzin.DTO_;
using Crudzin.Entity;
using MinhaPrimeiraAPI.Response;
using MinhaPrimeiraAPI.Response.Cidade;

namespace MinhaPrimeiraAPI.Contracts.Service
{
    public interface ICidadeService 
    {
        Task<CidadeGetAllResponse> GetAll();
        Task<CidadeEntity> GetById(int id);
        Task<MessageResponse> Post(CidadeInsertDTO cidade);
        Task<MessageResponse> Delete(int id);
        Task<MessageResponse> Update(CidadeEntity cidade);
    }
}
