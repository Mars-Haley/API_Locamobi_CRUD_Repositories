using Locamobi_CRUD_Repositories.DTO;
using Locamobi_CRUD_Repositories.Entity;
using Locamobi_CRUD_Repositories.Repository;
using MinhaPrimeiraAPI.Contracts.Service;
using MinhaPrimeiraAPI.Response;
using MinhaPrimeiraAPI.Response.Veiculo;

namespace MinhaPrimeiraAPI.Services
{
    public class VeiculoService : IVeiculoService
    {
        public async Task<MessageResponse> Delete(int id)//verificar esse id
        {
            VeiculoRepository _veiculoRepository = new VeiculoRepository();
            await _veiculoRepository.Delete(id);
            return new MessageResponse
            {
                Message = "Veiculo deletado com sucesso."
            };

        }

        public async Task<VeiculoGetAllResponse> GetAll()
        {
            VeiculoRepository _veiculoRepository = new VeiculoRepository();
            return new VeiculoGetAllResponse
            {
                Data = await _veiculoRepository.GetAll()
            };

        }

        public async Task<VeiculoEntity> GetByCodVeiculo(int codVeiculo)
        {
            VeiculoRepository _veiculosRepository = new VeiculoRepository();
            return await _veiculosRepository.GetByCodVeiculo(codVeiculo);
        }

        public async Task<MessageResponse> Post(VeiculoInsertDTO veiculo)
        {
            VeiculoRepository _veiculoRepository = new VeiculoRepository();
            await _veiculoRepository.Insert(veiculo);
            return new MessageResponse
            {
                Message = "Veiculo cadastrado com sucesso."
            };
        }

        public async Task<MessageResponse> Update(VeiculoEntity veiculo)
        {
            VeiculoRepository _veiculoRepository = new VeiculoRepository();
            await _veiculoRepository.Update(veiculo);
            return new MessageResponse
            {
                Message = "Veiculo atualizado com sucesso."
            };


        }
    }
}
