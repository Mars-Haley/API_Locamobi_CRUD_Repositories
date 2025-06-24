using User.Entity;

namespace User.Response.User
{
    public class UserGetAllResponse
    {
        public IEnumerable<UserEntity> Data { get; set; }
    }
}