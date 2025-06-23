using Models;

namespace Locamobi_CRUD_Repositories.Contracts.Token
{
    public interface ITokenService 
    {
        string Generate(VeiculoInfo? val);
    }



}
