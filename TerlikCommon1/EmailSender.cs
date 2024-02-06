using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Mail;
using System.Text;
using System.Threading.Tasks;

namespace TerlikCommon
{
    public class EmailSender
    {

        public Task SendEmailAsync(string Name, string email, string subject, string body)
        {

            var message = new MailMessage();
            message.From = new MailAddress(email);

            
            message.Subject = subject;
            message.Body = body;
            message.IsBodyHtml = true;




            var mail = "peluche@groupsade.com";
            var pw = "Peluche2020++";

            var client = new SmtpClient("smtp.groupsade.com", 465)
            {
                Credentials = new System.Net.NetworkCredential(mail, pw),
                EnableSsl = true

            };

            return client.SendMailAsync(
                new System.Net.Mail.MailMessage(mail, email, subject, body)
                {
                    IsBodyHtml = true,
                    

                }
                );
              



        }

    }
}
