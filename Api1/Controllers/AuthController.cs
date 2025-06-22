using Api1.Contracts.Service;
using Api1.Models;
using Microsoft.AspNetCore.Mvc;

namespace Api1.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class AuthController : ControllerBase
    {
        private readonly IUserService _userService;
        private readonly ITokenService _tokenService;
        public AuthController(IUserService userService, ITokenService tokenService){
            _userService = userService;
            _tokenService = tokenService;
        }

        [HttpPost("Login")]
        public async Task<IActionResult> Login([FromBody] LoginRequest request)
        {
            var user = await _userService.ValidateUser(request.Email, request.Password);
            if (user == null)
                return BadRequest("Invalid credentials");
            var token = _tokenService.GenerateToken(user);
            return Ok(token);
        }
    }

}