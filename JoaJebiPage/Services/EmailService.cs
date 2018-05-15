using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Mail;
using System.Security.Cryptography;
using System.Threading.Tasks;

namespace JoaJebiPage.Services
{
    public class EmailService
    {
        private static EmailService instance;

        private EmailService() { }

        public static EmailService Instance
        {
            get
            {
                if (instance == null)
                {
                    instance = new EmailService();
                }
                return instance;
            }
        }
        /**
         * EMail-account and EMail-Password
         */
        private const string password = "JoaJebi1";
        private const string sender = "internettechnology2018@hotmail.com";

        /**
         * Inspiration from:
         * https://stackoverflow.com/questions/2470645/sending-mail-using-smtpclient-in-net
         * https://stackoverflow.com/questions/9201239/send-e-mail-via-smtp-using-c-sharp
         * https://stackoverflow.com/questions/9851319/how-to-add-smtp-hotmail-account-to-send-mail
         */
        public async Task SendEmail(string email, string name, string message, string subject)
        {
            try
            {
                var msg = new MailMessage();
                msg.To.Add(email);
                msg.Subject = subject;
                msg.From = new MailAddress(sender);
                msg.Body = message;
                var smtpServer = new SmtpClient("smtp.live.com")
                {
                    Port = 587,
                    Credentials = new NetworkCredential(sender, password),
                    EnableSsl = true
                };
                await smtpServer.SendMailAsync(msg);
            }
            catch (SmtpException e)
            {
                Console.WriteLine(e);
            }
            
        }
    }
}
