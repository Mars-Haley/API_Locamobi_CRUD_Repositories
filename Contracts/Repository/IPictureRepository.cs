using Locamobi.Entity;
using User.DTO;

namespace Locamobi.Contracts.Repository;

public interface IPictureRepository
{
    Task<IEnumerable<PictureEntity>> GetAll();
    Task<PictureEntity> GetById(int id);
    Task Insert(PictureInsertDTO picture);
    Task Update(PictureEntity picture);
    Task Delete(int id);
}