using System;
using System.Net.Mail;
using System.Threading.Tasks;

namespace TerlikCommon
{
    public class EmailSender
    {
        public async Task SendEmailAsync(string email, string subject, string body)
        {
            try
            {
                var mail = "peluche@groupsade.com";
                var pw = "Peluche2020++"; // Replace with the actual password

                using (var message = new MailMessage())
                {
                    message.From = new MailAddress(email);
                    message.To.Add(mail);
                    message.Subject = subject;
                    message.Body = body;
                    message.IsBodyHtml = true;

                    using (var client = new SmtpClient("srvc21.turhost.com", 587))
                    {
                        client.Credentials = new System.Net.NetworkCredential(mail, pw);
                        client.EnableSsl = true;

                        await client.SendMailAsync(message);
                    }
                }
            }
            catch (Exception ex)
            {
                // Handle exceptions here (e.g., log the error)
                Console.WriteLine($"Error sending email: {ex.Message}");
            }
        }
    }
}
