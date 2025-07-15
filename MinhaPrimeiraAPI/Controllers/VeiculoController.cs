using System.Linq;
using Locamobi_CRUD_Repositories.DTO;
using Locamobi_CRUD_Repositories.Entity;
using Microsoft.AspNetCore.Mvc;
using MinhaPrimeiraAPI.Contracts.Service;
using MinhaPrimeiraAPI.Response;
using MinhaPrimeiraAPI.Response.Veiculo;
using MinhaPrimeiraAPI.Services;

namespace MinhaPrimeiraAPI.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class VeiculoController : ControllerBase
    {
        private IVeiculoService _veiculoService;

       public VeiculoController(IVeiculoService veiculoService)
        {
            _veiculoService = veiculoService;
        }

        [HttpGet]
        public async Task<ActionResult<VeiculoGetAllResponse>> Get()
        {
            return Ok(await _veiculoService.GetAll());
        }

        [HttpGet("{codVeiculo}")]
        public async Task<ActionResult<VeiculoEntity>> GetByCodVeiculo(int codVeiculo)
        {
            return Ok(await _veiculoService.GetByCodVeiculo(codVeiculo));
        }

        [HttpPost]
        public async Task<ActionResult<MessageResponse>> Post(VeiculoInsertDTO postVeiculo)
        {
            return Ok(await _veiculoService.Post(postVeiculo));
        }

        [HttpDelete("{codVeiculo}")]
        public async Task<ActionResult<MessageResponse>> Delete(int codVeiculo)
        {
            return Ok(await _veiculoService.Delete(codVeiculo));
        }

        [HttpPut]
        public async Task<ActionResult<MessageResponse>> Update(VeiculoEntity updateVeiculo)
        {
            return Ok(await _veiculoService.Update(updateVeiculo));
        }



    }
}
