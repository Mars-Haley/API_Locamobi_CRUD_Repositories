using Api1.Entity;

namespace Api1.Response.User
{
    public class UserGetAllResponse
    {
        public IEnumerable<UserEntity> Data { get; set; }
    }
}