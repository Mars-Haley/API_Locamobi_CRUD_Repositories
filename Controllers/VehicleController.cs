using System.Linq;
using Locamobi_CRUD_Repositories.DTO;
using Locamobi_CRUD_Repositories.Entity;
using Locamobi.Contracts.Service;
using Locamobi.Response;
using Locamobi.Response.Veiculo;
using Microsoft.AspNetCore.Mvc;
using Locamobi.Services;

namespace Locamobi.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class VehicleController : ControllerBase
    {
        private IVehicleService _vehicleService;

       public VehicleController(IVehicleService vehicleService)
        {
            _vehicleService = vehicleService;
        }

        [HttpGet]
        public async Task<ActionResult<VeiculoGetAllResponse>> Get()
        {
            return Ok(await _vehicleService.GetAll());
        }

        [HttpGet("{codVeiculo}")]
        public async Task<ActionResult<VehicleEntity>> GetByCodVeiculo(int codVeiculo)
        {
            return Ok(await _vehicleService.GetByCodVeiculo(codVeiculo));
        }

        [HttpPost]
        public async Task<ActionResult<MessageResponse>> Post(VehicleInsertDTO postVehicle)
        {
            return Ok(await _vehicleService.Post(postVehicle));
        }

        [HttpDelete("{codVeiculo}")]
        public async Task<ActionResult<MessageResponse>> Delete(int codVeiculo)
        {
            return Ok(await _vehicleService.Delete(codVeiculo));
        }

        [HttpPut]
        public async Task<ActionResult<MessageResponse>> Update(VehicleEntity updateVehicle)
        {
            return Ok(await _vehicleService.Update(updateVehicle));
        }



    }
}
