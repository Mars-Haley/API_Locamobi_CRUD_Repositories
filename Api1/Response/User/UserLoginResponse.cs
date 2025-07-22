using Locamobi.Entity;

namespace Locamobi.Response.User;

public class UserLoginResponse
{
    public string Token { get; set; }
    public UserEntity User { get; set; }
}