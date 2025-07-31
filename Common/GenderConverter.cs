using Locamobi.Enums;

namespace Locamobi.Common
{
    public static class GenderConverter
    {
        public static string ToPortuguese(Gender gender) => gender switch
        {
            Gender.Man => "HOMEM",
            Gender.Woman => "MULHER",
            Gender.NonBinary => "NB",
            Gender.NotAssigned => "N/A",
            _ => throw new ArgumentOutOfRangeException(nameof(gender), gender, null)
        };
        
        public static Gender FromPortuguese(string text) => text switch
        {
            "HOMEM" => Gender.Man,
            "MULHER" => Gender.Woman,
            "NB" => Gender.NonBinary,
            "N/A" => Gender.NotAssigned,
            _ => throw new ArgumentOutOfRangeException(nameof(text), text, null)
        };
    }
}
