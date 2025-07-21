using System.ComponentModel;

namespace User.Enums;

public enum Gender
{
    [Description("Homem")]
    Man = 0,
    [Description("Mulher")]
    Woman = 1,
    [Description("Não Binário")]
    NonBinary = 2,
    [Description("Prefere Não Dizer")]
    NotAssigned = 3
}