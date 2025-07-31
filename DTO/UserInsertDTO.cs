using Locamobi.Enums;
using Locamobi.Common;

namespace Locamobi.DTO
{
    public class UserInsertDTO
    {
        public string Name { get; set; }
        public string Email { get; set; }
        public string Cpf { get; set; }
        public string Password { get; set; }
        public string PhoneNumber { get; set; }
        public string Address { get; set; }
        public int CityId { get; set; }
        public DateTime Birthday { get; set; }
        public Gender Gender { get; set; }
        
        public string GenderText
        {
            get => GenderConverter.ToPortuguese(Gender);
            set => Gender = GenderConverter.FromPortuguese(value);
        }
    }
}