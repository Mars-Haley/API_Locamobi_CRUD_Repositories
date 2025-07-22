using System.Security.Cryptography;

namespace Locamobi.Infrastructure;

public class Cryptography
{
    public static string Encrypt(string plainText)
    {
        var salt = new byte[] { 1, 2, 3, 4, 5, 6 };
        var rfc = new Rfc2898DeriveBytes(plainText, salt, 10000);
        byte[ ] key = rfc.GetBytes(32);
        return BitConverter.ToString(key).Replace("-", String.Empty).ToLower();
    }
}