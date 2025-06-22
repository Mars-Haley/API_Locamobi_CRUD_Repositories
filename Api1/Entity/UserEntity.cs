using System.ComponentModel.DataAnnotations.Schema;

namespace Api1.Entity
{
    [Table("USUARIO")]
    public class UserEntity
    {
        public int Id { get; set; }
        [Column("NOME")]
        public string Name { get; set; }
        public string Email { get; set; }
        private string _password { get; set; }
        public string PhoneNumber { get; set; }
        public string Address { get; set; }
        [Column("CIDADE_CODCID")]
        public int CityId { get; set; }

        public string Password
        {
            get { return _password; }
            set { _password = value; }
        }


        public UserEntity(int id, string name, string email, string password, string phoneNumber, string address, int cityId)
        {
            Id = id;
            Name = name;
            Email = email;
            Password = password;
            PhoneNumber = phoneNumber;
            Address = address;
            CityId = cityId;
        }
    }
}
