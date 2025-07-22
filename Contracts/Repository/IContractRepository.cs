using Locamobi.DTO;
using Locamobi.Entity;

namespace Locamobi.Contracts.Repository
{
    public interface IContractRepository
    {
        Task<IEnumerable<ContractEntity>> GetAll();

        Task Insert(ContractInsertDTO contrato);

        Task Update(ContractEntity contrato);

        Task<ContractEntity> GetById(int id);

        Task Delete(int id);
    }
}