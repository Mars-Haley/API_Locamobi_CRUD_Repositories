using API_Locamobi_CRUD_Repositories.DTO;
using API_Locamobi_CRUD_Repositories.Entity;

namespace API_Locamobi_CRUD_Repositories.Contracts.Repository
{
    public interface IContratoRepository
    {
        Task<IEnumerable<ContratoEntity>> GetAll();

        Task Insert(ContratoInsertDTO contrato);

        Task Update(ContratoEntity contrato);

        Task<ContratoEntity> GetById(int id);

        Task DeleteById(int id);

        Task Delete(int id);
    }
}