using Microsoft.AspNetCore.Mvc;
using Api1.Repository;
using Api1.Contracts.Service;
using Api1.Services;
using Api1.Response.User;
using Api1.DTO;
using Api1.Response;
using Api1.Entity;

namespace Api1.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class UserController : ControllerBase
    {
        private IUserService _service;

        public UserController()
        {
            _service = new UserService();
        }
        [HttpGet]
        public async Task<ActionResult<UserGetAllResponse>> Get()
        {
            UserRepository _repository = new UserRepository();
            return Ok(await _repository.GetAll());
        }

        [HttpGet("{id}")]
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
        public async Task<ActionResult<MessageResponse>> Delete(int id)
        {
            return Ok(await _service.Delete(id));
        }

        [HttpPut]
        public async Task<ActionResult<MessageResponse>> Update(UserEntity user)
        {
            return Ok(await _service.Update(user));
        }

    }
}
