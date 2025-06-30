using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Security.Cryptography;
using System.Text;
using System.Text.Json;
using Microsoft.IdentityModel.Tokens;
using User.Contracts.Infrastructure;
using User.Entity;

namespace User.Infrastructure
{
    public class Authentication : IAuthentication
    {
        private readonly IConfiguration _configuration;

        public Authentication(IConfiguration configuration)
        {
            _configuration = configuration;
        }
        public string GenerateToken(UserEntity user)
        {
            var handler = new JwtSecurityTokenHandler();

            var key = Encoding.ASCII.GetBytes(_configuration["JwtSettings:SecretKey"]);

            var credentials = new SigningCredentials(
                new SymmetricSecurityKey(key),
                SecurityAlgorithms.HmacSha256Signature);

            var tokenDescriptor = new SecurityTokenDescriptor
            {
                Subject = new ClaimsIdentity(new []
                {
                new Claim(ClaimTypes.Name, user.Name),
                new Claim(ClaimTypes.Email, user.Email),
                new Claim(ClaimTypes.MobilePhone, user.PhoneNumber),
                new Claim("Address", JsonSerializer.Serialize(new
                {
                    address = user.Address,
                    city = user.CityId
                }))
            }),

                Expires = DateTime.UtcNow.AddHours(2),
                SigningCredentials = credentials,
                Issuer = JwtConfig.Issuer,
                Audience = JwtConfig.Audience
            };
            var token = handler.CreateToken(tokenDescriptor);
            return handler.WriteToken(token);

        }

        public string GenerateRefreshToken()
        {
            var randomNumber = new byte[64];
            using var rng = RandomNumberGenerator.Create();
            rng.GetBytes(randomNumber);
            return Convert.ToBase64String(randomNumber);
        }

        public ClaimsPrincipal GetPrincipalFromExpiredToken(string token)
        {
            var tokenValidationParameters = new TokenValidationParameters
            {
                ValidateAudience = true,
                ValidAudience = JwtConfig.Audience,
                ValidateIssuer = true,
                ValidIssuer = JwtConfig.Issuer,
                ValidateIssuerSigningKey = true,
                IssuerSigningKey = new SymmetricSecurityKey(Encoding.ASCII.GetBytes(_configuration["JwtSettings:SecretKey"])),
                ValidateLifetime = false
            };
            var tokenHandler = new JwtSecurityTokenHandler();
            var principal = tokenHandler.ValidateToken(token, tokenValidationParameters, out SecurityToken securityToken);
            if (securityToken is not JwtSecurityToken jwtSecurityToken ||
                !jwtSecurityToken.Header.Alg.Equals(SecurityAlgorithms.HmacSha256, StringComparison.InvariantCultureIgnoreCase))
                throw new SecurityTokenException("Invalid token");
            return principal;
        }
        public ClaimsIdentity GenerateClaims(UserEntity user)
        {
            var ci = new ClaimsIdentity();
            var addressJson = JsonSerializer.Serialize(new
            {
                address = user.Address,
                city = user.CityId
            });
            ci.AddClaim(new Claim(ClaimTypes.Name, user.Name));
            ci.AddClaim(new Claim("Address", addressJson));
            ci.AddClaim(new Claim(ClaimTypes.Email, user.Email));
            ci.AddClaim(new Claim(ClaimTypes.MobilePhone, user.PhoneNumber));
            return ci;
        }
    }
}
