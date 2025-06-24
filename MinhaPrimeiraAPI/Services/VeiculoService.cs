using System.Text.RegularExpressions;
using Locamobi_CRUD_Repositories.Contracts.Repository;
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

        private IVeiculoRepository _veiculoRepository;

        public VeiculoService(IVeiculoRepository veiculoRepository)
        {
            _veiculoRepository = veiculoRepository;
        }

        public async Task<MessageResponse> Delete(int id)//verificar esse id
        {
            await _veiculoRepository.Delete(id);
            return new MessageResponse
            {
                Message = "Veiculo deletado com sucesso."
            };

        }

        public async Task<VeiculoGetAllResponse> GetAll()
        {
            return new VeiculoGetAllResponse
            {
                Data = await _veiculoRepository.GetAll()
            };

        }


        public async Task<VeiculoEntity> GetByCodVeiculo(int codVeiculo)
        {
            return await _veiculoRepository.GetByCodVeiculo(codVeiculo);
        }

        public async Task<MessageResponse> Post(VeiculoInsertDTO veiculo)
        {
            await _veiculoRepository.Insert(veiculo);
            return new MessageResponse
            {
                Message = "Veiculo cadastrado com sucesso."
            };
        }

        public async Task<MessageResponse> Update(VeiculoEntity veiculo)
        {
            await _veiculoRepository.Update(veiculo);
            return new MessageResponse
            {
                Message = "Veiculo atualizado com sucesso."
            };


        }
    }
}
