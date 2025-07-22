using Locamobi.Contracts.Repository;
using Locamobi.Contracts.Service;
using Locamobi.DTO;
using Locamobi.Entity;
using Locamobi.Response;

namespace Locamobi.Services
{
    public class ContractService : IContractService
    {
        private IContractRepository _repository;

        public ContractService(IContractRepository repository)
        {
            _repository = repository;
        }
        public async Task<MessageResponse> Delete(int id)
        {
            await _repository.Delete(id);
            return new MessageResponse 
            { 
                Message= "Contrato excluído com sucesso!"
            };

        }

        public async Task<ContractGetAllResponse> GetAll()
        {
            return new ContractGetAllResponse
            {
                Data = await _repository.GetAll()
            };
        }

        public async Task<ContractEntity> GetById(int id)
        {
            return await _repository.GetById(id);
        }

        public async Task<MessageResponse> Post(ContractInsertDTO contrato)
        {
            await _repository.Insert(contrato);
            return new MessageResponse
            {
                Message = "Contrato inserido com sucesso!"
            };
        }

        public async Task<MessageResponse> Update(ContractEntity contrato)
        {
            await _repository.Update(contrato);
            return new MessageResponse
            {
                Message = "Contrato alterado com sucesso!"
            };
        }
    }
}