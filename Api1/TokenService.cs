using Api1.Entity;
using Api1.Models;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Security.Cryptography;
using System.Text;
using System.Text.Json;

namespace Api1
{
    public class TokenService
    {
        public TokenResponse GenerateToken(UserEntity user)
        {
            var handler = new JwtSecurityTokenHandler();

            var key = Encoding.ASCII.GetBytes(Configuration.PrivateKey);

            var credentials = new SigningCredentials(
                new SymmetricSecurityKey(key),
                SecurityAlgorithms.HmacSha256Signature);

            var tokenDescriptor = new SecurityTokenDescriptor
            {
                Subject = new ClaimsIdentity(new[]
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
                Issuer = "http://localhost:5150",
                Audience = "http://localhost:5150"
            };
            var token = handler.CreateToken(tokenDescriptor);
            var accessToken = handler.WriteToken(token);
            var refreshToken = GenerateRefreshToken();

            return new TokenResponse
            {
                AccessToken = accessToken,
                RefreshToken = refreshToken,
                ExpiresIn = 7200
            };
        }

        private string GenerateRefreshToken()
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
                ValidateAudience = false,
                ValidateIssuer = false,
                ValidateIssuerSigningKey = true,
                IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(Configuration.PrivateKey)),
                ValidateLifetime = false
            };
            var tokenHandler = new JwtSecurityTokenHandler();
            var principal = tokenHandler.ValidateToken(token, tokenValidationParameters, out SecurityToken securityToken);
            if (securityToken is not JwtSecurityToken jwtSecurityToken || !jwtSecurityToken.Header.Alg.Equals(SecurityAlgorithms.HmacSha256, StringComparison.InvariantCultureIgnoreCase))
                throw new SecurityTokenException("Invalid token");
            return principal;
        }
        private static ClaimsIdentity GenerateClaims(UserEntity user)
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
