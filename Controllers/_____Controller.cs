using API_Locamobi_CRUD_Repositories.Contracts.Service;
using API_Locamobi_CRUD_Repositories.DTO;
using API_Locamobi_CRUD_Repositories.Entity;
using API_Locamobi_CRUD_Repositories.Response;
using API_Locamobi_CRUD_Repositories.Response._____;
using API_Locamobi_CRUD_Repositories.Services;
using Microsoft.AspNetCore.Mvc;

namespace API_Locamobi_CRUD_Repositories.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class _____Controller : ControllerBase
    {
        private I_____Service _service;

        public _____Controller()
        {
            _service = new _____Service();
        }

        [HttpGet]
        public async Task<ActionResult<_____GetAllResponse>> Get()
        {
            return Ok(await _service.GetAll());
        }

        [HttpPost]
        public async Task<ActionResult<MessageResponse>> Post(_____InsertDTO _____)
        {
            return Ok(await _service.Post(_____));
        }


        [HttpDelete("{id}")]
        public async Task<ActionResult<MessageResponse>> Delete(int id)
        {
            return Ok(await _service.Delete(id));
        }

        [HttpPut]
        public async Task<ActionResult<MessageResponse>> Update(_____Entity _____)
        {
            return Ok(await _service.Update(_____));
        }
    }
}