using Locamobi.Services;
using Locamobi.Contracts.Service;
using Locamobi.DTO;
using Locamobi.Entity;
using Locamobi.Response;
using Microsoft.AspNetCore.Mvc;
using Locamobi.Contracts.Repository;

namespace Locamobi.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class ContractController : ControllerBase
    {
        private IContractService _service;
        private IContractRepository _repository;

        public ContractController(IContractService contractService, IContractRepository contractRepository)
        {
            _service = contractService;
            _repository = contractRepository;
        }

        [HttpGet]
        public async Task<ActionResult<ContractGetAllResponse>> Get()
        {
            return Ok(await _service.GetAll());
        }

        [HttpPost]
        public async Task<ActionResult<MessageResponse>> Post(ContractInsertDTO contrato)
        {
            return Ok(await _service.Post(contrato));
        }


        [HttpDelete("{id}")]
        public async Task<ActionResult<MessageResponse>> Delete(int id)
        {
            return Ok(await _service.Delete(id));
        }

        [HttpPut]
        public async Task<ActionResult<MessageResponse>> Update(ContractEntity contrato)
        {
            return Ok(await _service.Update(contrato));
        }
    }
}