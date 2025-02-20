using System.Net.Mail;

namespace HapoTravelRequest.Services
{
    public class EmailSender(IConfiguration _configuration) : IEmailSender
    {
        public async Task SendEmailAsync(string email, string subject, string msg)
        {
            var fromAddress = _configuration["EmailSettings:DefaultEmailAddress"];
            var smtpServer = _configuration["EmailSettings:Server"];
            var smtpPort = Convert.ToInt32(_configuration["EmailSettings:Port"]);
            var message = new MailMessage
            {
                From = new MailAddress(fromAddress),
                Subject = subject,
                Body = msg,
                IsBodyHtml = true
            };

            // recipient email
            message.To.Add(new MailAddress(email));

            using var client = new SmtpClient(smtpServer, smtpPort);
            await client.SendMailAsync(message);
        }
    }
}
