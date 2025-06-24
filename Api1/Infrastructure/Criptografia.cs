using System.Security.Cryptography;

namespace User.Infrastructure;

public class Criptografia
{
    public static string Criptografar(string password)
    {
        var salt = new byte []{ 1, 2, 3, 4, 5, 6, 7, 8};
        var rfc = new Rfc2898DeriveBytes(password, salt, 10000);
        byte[] key = rfc.GetBytes(32);
        return BitConverter.ToString(key).Replace("-", String.Empty).ToLower();
    }
}