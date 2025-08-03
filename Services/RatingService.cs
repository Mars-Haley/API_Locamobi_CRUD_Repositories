using System.Collections.Generic;
using System.Threading.Tasks;
using Locamobi.Contracts.Repository;
using Locamobi.Contracts.Service;
using Locamobi.Entity;

namespace Locamobi.Services 
{
    public class RatingService : IRatingService
    {
        private readonly IRatingRepository _ratingRepository;

        public RatingService(IRatingRepository ratingRepository)
        {
            _ratingRepository = ratingRepository;
        }

        public async Task<IEnumerable<RatingEntity>> GetAllAvaliacoes()
        {
            return await _ratingRepository.GetAllAsync();
        }

        public async Task<RatingEntity> GetAvaliacaoById(int id)
        {
            return await _ratingRepository.GetByIdAsync(id);
        }

        public async Task<IEnumerable<RatingEntity>> GetAvaliacoesByVeiculoCod(int veiculoCod)
        {
            return await _ratingRepository.GetByVeiculoCodAsync(veiculoCod);
        }

        public async Task<IEnumerable<RatingEntity>> GetAvaliacoesByUsuarioCod(int usuarioCod)
        {
            return await _ratingRepository.GetByUsuarioCodAsync(usuarioCod);
        }
    }
}