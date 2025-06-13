using Api1.Models;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using System.Text.Json;

namespace Api1
{
    public class TokenService
    {
        public string GenerateToken(User user) {
            var handler = new JwtSecurityTokenHandler();

            var key = Encoding.ASCII.GetBytes(Configuration.PrivateKey);

            var credentials = new SigningCredentials(
                new SymmetricSecurityKey(key),
                SecurityAlgorithms.HmacSha256Signature);

        var tokenDescriptor = new SecurityTokenDescriptor
        {
            Subject = GenerateClaims(user),
            Expires = DateTime.UtcNow.AddHours(2),
            SigningCredentials = credentials,
        };
            var token = handler.CreateToken(tokenDescriptor);
            return handler.WriteToken(token);
         }
        private static ClaimsIdentity GenerateClaims(User user) {
            var ci = new ClaimsIdentity();
            var addressJson = JsonSerializer.Serialize(new
            {
                address = user.Address, 
                city = user.CityId
            }) ;
            ci.AddClaim(new Claim(ClaimTypes.Name, user.Name));
            ci.AddClaim(new Claim("Address", addressJson));
            ci.AddClaim(new Claim(ClaimTypes.Email, user.Email));
            ci.AddClaim(new Claim(ClaimTypes.MobilePhone, user.PhoneNumber));
            return ci;
        }
    }
}
