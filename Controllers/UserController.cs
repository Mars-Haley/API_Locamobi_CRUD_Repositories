using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Locamobi.Contracts.Repository;
using Locamobi.Contracts.Service;
using Locamobi.DTO;
using Locamobi.Entity;
using Locamobi.Response;
using Locamobi.Response.User;

namespace Locamobi.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class UserController : ControllerBase
    {
        private IUserService _service;
        private IUserRepository _repository;

        public UserController(IUserService userService, IUserRepository userRepository)
        {
            _service = userService;
            _repository = userRepository;
        }
        [HttpGet]
        [Authorize]
        public async Task<ActionResult<UserGetAllResponse>> Get()
        {
            return Ok(await _repository.GetAll());
        }

        [HttpGet("{id}")]
        [Authorize]
        public async Task<ActionResult<UserGetAllResponse>> GetById(int id)
        {
            return Ok(await _service.GetById(id));
        }

        [HttpPost]
        public async Task<ActionResult> Post(UserInsertDTO user)
        {
            return Ok(await _service.Post(user));
        }



        [HttpDelete("{id}")]
        [Authorize]
        public async Task<ActionResult<MessageResponse>> Delete(int id)
        {
            return Ok(await _service.Delete(id));
        }

        [HttpPut]
        [Authorize]
        public async Task<ActionResult<MessageResponse>> Update(UserEntity user)
        {
            return Ok(await _service.Update(user));
        }

    }
}
