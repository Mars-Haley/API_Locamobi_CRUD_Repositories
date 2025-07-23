using Locamobi.Entity;

namespace Locamobi.Contracts.Repository 
{
    public interface IRatingRepository
    {
        Task<IEnumerable<RatingEntity>> GetAllAsync();
        Task<RatingEntity> GetByIdAsync(int id);
        Task<IEnumerable<RatingEntity>> GetByVeiculoCodAsync(int veiculoCod);
        Task<IEnumerable<RatingEntity>> GetByUsuarioCodAsync(int usuarioCod);
    }
}