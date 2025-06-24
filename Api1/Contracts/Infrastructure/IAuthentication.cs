using System.Security.Claims;
using User.Entity;

namespace User.Contracts.Infrastructure;

public interface IAuthentication
{
    string GenerateToken(UserEntity user);
    string GenerateRefreshToken();
    ClaimsPrincipal GetPrincipalFromExpiredToken(string token);
    ClaimsIdentity GenerateClaims (UserEntity user);
}