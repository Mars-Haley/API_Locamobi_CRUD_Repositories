using System.Security.Claims;
using Locamobi.Entity;

namespace Locamobi.Contracts.Infrastructure;

public interface IAuthentication
{
    string GenerateToken(UserEntity user);
    string GenerateRefreshToken();
    ClaimsPrincipal GetPrincipalFromExpiredToken(string token);
    ClaimsIdentity GenerateClaims (UserEntity user);
}