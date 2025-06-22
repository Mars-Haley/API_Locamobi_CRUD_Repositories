using System.Security.Claims;
using Api1.Entity;
using Api1.Models;

namespace Api1.Contracts.Service;

public interface ITokenService
{
    TokenResponse GenerateToken(UserEntity user);
    string GenerateRefreshToken();
    ClaimsPrincipal GetPrincipalFromExpiredToken(string token);
    ClaimsIdentity GenerateClaims (UserEntity user);
}