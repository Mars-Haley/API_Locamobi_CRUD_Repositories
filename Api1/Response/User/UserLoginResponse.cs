using User.Entity;

namespace User.Response.User;

public class UserLoginResponse
{
    public string Token { get; set; }
    public UserEntity User { get; set; }
}