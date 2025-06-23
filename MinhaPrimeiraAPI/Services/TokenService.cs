using ConfigurationPrivateKey;
using System.Drawing;
using System.IdentityModel.Tokens.Jwt;
using System.Text;
using Microsoft.IdentityModel.Tokens;
using Models;
using Locamobi_CRUD_Repositories.Contracts.Token;
using System.Security.Claims;

namespace Services;


public class TokenService : ITokenService
{
    //e preciso ter injeçao de dependecia no TokenService
    public string Generate(VeiculoInfo veiculo) 
    {
        var handler = new JwtSecurityTokenHandler();

        var key = Encoding.UTF8.GetBytes(Configuration.PrivateKey);

        var credentials = new SigningCredentials(new SymmetricSecurityKey(key),
            SecurityAlgorithms.HmacSha256Signature);

        var claims = GenerateClaims(veiculo);

        var tokenDescriptor = new SecurityTokenDescriptor
        {
            Subject = new ClaimsIdentity(claims),
            SigningCredentials = credentials,
            Expires = DateTime.UtcNow.AddHours(2),
        };


        var token = handler.CreateToken(tokenDescriptor);

        return handler.WriteToken(token);

    }

    private static IEnumerable<Claim> GenerateClaims(VeiculoInfo veiculo)
    {
        return new List<Claim>
    {
        new Claim("CodVeiculo", veiculo.CodVeiculo.ToString()),
        new Claim("Modelo", veiculo.Modelo),
        new Claim("Marca", veiculo.Marca),
        new Claim("Ano", veiculo.Ano.ToString()),
        new Claim("Placa", veiculo.Placa),
        new Claim("Cor", veiculo.Cor),
        new Claim("Cidade_CodCid", veiculo.Cidade_CodCid.ToString()),
        new Claim("Classific", veiculo.Classific),
        new Claim("Tipo", veiculo.Tipo),
        new Claim("Usuario_CodUser", veiculo.Usuario_CodUser.ToString())
    };
    }
}