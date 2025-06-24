using Microsoft.AspNetCore.Mvc;
using User.Contracts.Infrastructure;
using User.Contracts.Service;
using User.DTO;

namespace User.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class AuthController : ControllerBase
    {
        private readonly IUserService _userService;
        private readonly IAuthentication _authentication;
        public AuthController(IUserService userService, IAuthentication authentication){
            _userService = userService;
            _authentication = authentication;
        }

        [HttpPost("Login")]
        public async Task<IActionResult> Login([FromBody] UserLoginDTO dto)
        {
            var user = await _userService.ValidateUser(dto.Email, dto.Password);
            if (user == null)
                return BadRequest("Invalid credentials");
            var token = _authentication.GenerateToken(user);
            return Ok(token);
        }
    }

}