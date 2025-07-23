using Locamobi.Entity;

namespace Locamobi.Contracts.Service 
{
    public interface IRatingService
    {
        Task<IEnumerable<RatingEntity>> GetAllAvaliacoes();
        Task<RatingEntity> GetAvaliacaoById(int id);
        Task<IEnumerable<RatingEntity>> GetAvaliacoesByVeiculoCod(int veiculoCod);
        Task<IEnumerable<RatingEntity>> GetAvaliacoesByUsuarioCod(int usuarioCod);
    }
}