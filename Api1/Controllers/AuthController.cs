using Api1.DTO;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.ComponentModel.DataAnnotations;
using User.Contracts.Infrastructure;
using User.Contracts.Repository;
using User.Contracts.Service;
using User.DTO;
using User.Helpers;

namespace User.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class AuthController : ControllerBase
    {
        private readonly IUserService _userService;
        private readonly IAuthentication _authentication;
        private readonly IUserRepository _userRepository;
        public AuthController(IUserService userService, IAuthentication authentication, IUserRepository userRepository){
            _userService = userService;
            _authentication = authentication;
            _userRepository = userRepository;
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

        [HttpPost("HandShake")]
        [Authorize]
        public async Task<IActionResult> HandShake()
        {
            return Ok(new {});
        }

        [HttpPost("forgot-password")]
        public async Task<IActionResult> ForgotPassword([FromBody] ForgotPasswordDTO dto)
        {
            var token = Guid.NewGuid().ToString();
            var expira = DateTime.Now.AddHours(1);

            var ok = await _userRepository.SaveRecuperationToken(dto.Email, token, expira);
            if (!ok) return BadRequest("Email n�o encontrado.");

            // Aqui chamamos o helper para enviar o e-mail
            EmailHelper.Send(dto.Email, token);

            return Ok("Token enviado ao e-mail.");
        }

        [HttpPut("reset-password")]
        public async Task<IActionResult> ResetPassword([FromBody] ResetPasswordDTO dto)
        {
            // Ideal: aplicar hash na senha
            var ok = await _userRepository.UpdatePasswordByToken(dto.Token, dto.NewPassword);
            if (!ok) return BadRequest("Token inv�lido ou expirado.");

            return Ok("Senha atualizada com sucesso.");
        }
    }
}