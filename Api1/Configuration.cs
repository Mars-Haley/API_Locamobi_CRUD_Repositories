namespace Api1
{
    public class Configuration
    {
        public static string PrivateKey => Environment.GetEnvironmentVariable("JWT_PRIVATE_KEY")
        ?? throw new InvalidOperationException("JWT_PRIVATE_KEY is not set.");

    }
}
