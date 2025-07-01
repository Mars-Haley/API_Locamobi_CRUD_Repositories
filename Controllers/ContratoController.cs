using API_Locamobi_CRUD_Repositories.Contracts.Service;
using API_Locamobi_CRUD_Repositories.DTO;
using API_Locamobi_CRUD_Repositories.Entity;
using API_Locamobi_CRUD_Repositories.Response;
using API_Locamobi_CRUD_Repositories.Services;
using Microsoft.AspNetCore.Mvc;

namespace API_Locamobi_CRUD_Repositories.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class ContratoController : ControllerBase
    {
        private IContratoService _service;

        public ContratoController()
        {
            _service = new ContratoService();
        }

        [HttpGet]
        public async Task<ActionResult<ContratoGetAllResponse>> Get()
        {
            return Ok(await _service.GetAll());
        }

        [HttpPost]
        public async Task<ActionResult<MessageResponse>> Post(ContratoInsertDTO contrato)
        {
            return Ok(await _service.Post(contrato));
        }


        [HttpDelete("{id}")]
        public async Task<ActionResult<MessageResponse>> Delete(int id)
        {
            return Ok(await _service.Delete(id));
        }

        [HttpPut]
        public async Task<ActionResult<MessageResponse>> Update(ContratoEntity contrato)
        {
            return Ok(await _service.Update(contrato));
        }
    }
}