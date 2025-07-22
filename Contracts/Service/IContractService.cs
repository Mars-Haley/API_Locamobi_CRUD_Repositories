using Locamobi.DTO;
using Locamobi.Entity;
using Locamobi.Response;

namespace Locamobi.Contracts.Service
{
    public interface IContractService
    {
        Task<MessageResponse> Delete(int id);

        Task<ContractGetAllResponse> GetAll();

        Task<ContractEntity> GetById(int id);

        Task<MessageResponse> Post(ContractInsertDTO contrato);

        Task<MessageResponse> Update(ContractEntity contrato);
    }
}