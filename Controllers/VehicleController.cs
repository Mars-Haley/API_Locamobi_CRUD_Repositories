using System.Linq;
using Locamobi.DTO;
using Locamobi.Entity;
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

        [HttpGet("{id}")]
        public async Task<ActionResult<VehicleEntity>> GetById(int id)
        {
            return Ok(await _vehicleService.GetById(id));
        }

        [HttpPost]
        public async Task<ActionResult<MessageResponse>> Post(VehicleInsertDTO postVehicle)
        {
            return Ok(await _vehicleService.Post(postVehicle));
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult<MessageResponse>> Delete(int id)
        {
            return Ok(await _vehicleService.Delete(id));
        }

        [HttpPut]
        public async Task<ActionResult<MessageResponse>> Update(VehicleEntity updateVehicle)
        {
            return Ok(await _vehicleService.Update(updateVehicle));
        }



    }
}
