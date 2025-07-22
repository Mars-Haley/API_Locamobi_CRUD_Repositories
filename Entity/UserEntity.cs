using System.ComponentModel.DataAnnotations.Schema;
using Locamobi.Enums;

namespace Locamobi.Entity
{
    [Table("USUARIO")]
    public class UserEntity
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Cpf { get; set; }
        public string Email { get; set; }
        private string _password { get; set; }
        public string PhoneNumber { get; set; }
        public string Address { get; set; }
        public int CityId { get; set; }
        public DateTime Birthday { get; set; }
        public Gender Gender { get; set; }

        public string Password
        {
            get { return _password; }
            set { _password = value; }
        }

        public string GenderText
        {
            get => Gender.ToString();
            set => Gender = StringToGender(value);
        }

        private static string GenderToString(Gender gender) => gender switch
        {
            Gender.Man => "HOMEM",
            Gender.Woman => "MULHER",
            Gender.NonBinary => "NB",
            Gender.NotAssigned => "N/A",
            _ => throw new ArgumentOutOfRangeException(nameof(gender), gender, null)
        };

        private static Gender StringToGender(string text) => text switch
        {
            "HOMEM" => Gender.Man,
            "MULHER" => Gender.Woman,
            "NB" => Gender.NonBinary,
            "NA" => Gender.NotAssigned,
            _ => throw new ArgumentOutOfRangeException(nameof(text), text, null)
        };


        public UserEntity(int id, string name, string email, string password, string phoneNumber, string address, int cityId, DateTime birthday, Gender gender)
        {
            Id = id;
            Name = name;
            Email = email;
            Password = password;
            PhoneNumber = phoneNumber;
            Address = address;
            CityId = cityId;
            Birthday = birthday;
            Gender = gender;
        }

        public UserEntity(){}
    }
}
