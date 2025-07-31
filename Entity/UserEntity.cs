using System.ComponentModel.DataAnnotations.Schema;
using Locamobi.Enums;
using Locamobi.Common;

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
            get => GenderConverter.ToPortuguese(Gender);
            set => Gender = GenderConverter.FromPortuguese(value);
        }
        
        // Construtor completo
        public UserEntity(int id, string name, string cpf, string email, string password, 
            string phoneNumber, string address, int cityId, DateTime birthday, Gender gender)
        {
            Id = id;
            Name = name;
            Cpf = cpf;
            Email = email;
            Password = password;
            PhoneNumber = phoneNumber;
            Address = address;
            CityId = cityId;
            Birthday = birthday;
            Gender = gender;
        }
        
        public UserEntity() { }
    }
}