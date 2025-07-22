using System.Net.Mail;
using System.Net;

namespace Locamobi.Helpers
{
    public static class EmailHelper
    {
        public static void Send(string to, string token)
        {
            var sender = Environment.GetEnvironmentVariable("EMAIL_SENDER"); // email da locamobi, usar no terminal setx EMAIL_SENDER "seuemail@gmail.com"
            var passwordApp = Environment.GetEnvironmentVariable("EMAIL_PASSWORD"); //password app do gmail: setx EMAIL_PASSWORD "senha_do_app"  

            var smtp = new SmtpClient("smtp.gmail.com", 587)
            {
                Credentials = new NetworkCredential(sender, passwordApp),
                EnableSsl = true
            };

            var message = new MailMessage(sender, to)
            {
                Subject = "Recuperação de Senha",
                Body = $"Use este token para resetar sua senha: {token}"
            };

            smtp.Send(message);
        }
    }
}
