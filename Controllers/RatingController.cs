using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Threading.Tasks;
using Locamobi.Contracts.Service;
using Locamobi.Entity;

namespace Locamobi.Controllers 
{
    [ApiController]
    [Route("[controller]")] 
    public class RatingController : ControllerBase
    {
        private readonly IRatingService _ratingService;

        public RatingController(IRatingService ratingService)
        {
            _ratingService = ratingService;
        }

        // GET: /Avaliacao
        // Retorna todas as avaliações
        [HttpGet]
        public async Task<ActionResult<IEnumerable<RatingEntity>>> GetAll()
        {
            var avaliacoes = await _ratingService.GetAllAvaliacoes();
            if (avaliacoes == null || !avaliacoes.Any())
            {
                return NotFound("Nenhuma avaliação encontrada.");
            }
            return Ok(avaliacoes);
        }

        // GET: /Avaliacao/{id}
        // Retorna uma avaliação específica por seu CODAVA
        [HttpGet("{id}")]
        public async Task<ActionResult<RatingEntity>> GetById(int id)
        {
            var avaliacao = await _ratingService.GetAvaliacaoById(id);
            if (avaliacao == null)
            {
                return NotFound($"Avaliação com ID {id} não encontrada.");
            }
            return Ok(avaliacao);
        }

        // GET: /Avaliacao/veiculo/{veiculoCod}
        // Retorna avaliações de um veículo específico
        [HttpGet("veiculo/{veiculoCod}")]
        public async Task<ActionResult<IEnumerable<RatingEntity>>> GetByVeiculoCod(int veiculoCod)
        {
            var avaliacoes = await _ratingService.GetAvaliacoesByVeiculoCod(veiculoCod);
            if (avaliacoes == null || !avaliacoes.Any())
            {
                return NotFound($"Nenhuma avaliação encontrada para o veículo {veiculoCod}.");
            }
            return Ok(avaliacoes);
        }

        // GET: /Avaliacao/usuario/{usuarioCod}
        // Retorna avaliações relacionadas a um usuário (ex: avaliações recebidas pelos veículos do usuário)
        [HttpGet("usuario/{usuarioCod}")]
        public async Task<ActionResult<IEnumerable<RatingEntity>>> GetByUsuarioCod(int usuarioCod)
        {
            var avaliacoes = await _ratingService.GetAvaliacoesByUsuarioCod(usuarioCod);
            if (avaliacoes == null || !avaliacoes.Any())
            {
                return NotFound($"Nenhuma avaliação encontrada para o usuário {usuarioCod}.");
            }
            return Ok(avaliacoes);
        }
    }
}