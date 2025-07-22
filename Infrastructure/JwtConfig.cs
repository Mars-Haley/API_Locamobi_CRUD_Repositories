namespace Locamobi.Infrastructure
{
    public class JwtConfig
    {
        public static string PrivateKey => Environment.GetEnvironmentVariable("JWT_PRIVATE_KEY")
        ?? throw new InvalidOperationException("JWT_PRIVATE_KEY is not set.");

        public static string Issuer => Environment.GetEnvironmentVariable("JWT_ISSUER") ?? "http://localhost:5150";
        public static string Audience => Environment.GetEnvironmentVariable("JWT_AUDIENCE") ?? "http://localhost:5150";
    }
}
