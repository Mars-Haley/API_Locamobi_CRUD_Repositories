using Locamobi.Entity;

namespace Locamobi.Response.User
{
    public class UserGetAllResponse
    {
        public IEnumerable<UserEntity> Data { get; set; }
    }
}