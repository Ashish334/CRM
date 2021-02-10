using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Mail;
using System.Threading.Tasks;

namespace CRM.Server.Services
{
    // This class is used by the application to send email for account confirmation and password reset.
    // For more details see https://go.microsoft.com/fwlink/?LinkID=532713
    public class EmailSender : IEmailSender
    {
        public Task SendEmailAsync(string email, string subject, string message, bool isBodyHtml = false)
        {
            MailMessage msz = new MailMessage();

            msz.From = new MailAddress("no-reply@test.test");
            msz.To.Add(new MailAddress(email));// Change this where you want to receice the mail
            msz.Subject = subject;
            msz.Body = message;
            msz.IsBodyHtml = isBodyHtml;

            SmtpClient smtp = new SmtpClient();

            smtp.Host = "smtpout.secureserver.net";
            smtp.Host = "smtpout.asia.secureserver.net";
            //smtp.Host = "smtp.secureserver.net";

            smtp.Port = 25;
            smtp.DeliveryMethod = SmtpDeliveryMethod.Network;
            //Email address using which mail will send
            
            smtp.Credentials = new System.Net.NetworkCredential("no-reply@test.test", "testpassword");
            //smtp.UseDefaultCredentials = true;
            smtp.EnableSsl = false;

            smtp.Send(msz);
            return Task.CompletedTask;
        }
    }
}
