﻿using System;
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

        private const string password = "JoaJebi1";
        private const string sender = "internettechnology2018 @hotmail.com";

        public async Task SendEmail(string email, string name, string message, string subject)
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
    }
}
