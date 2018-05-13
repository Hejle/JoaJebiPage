using System;
using System.IO;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Diagnostics.Views;
using Microsoft.AspNetCore.Http;

namespace JoaJebiPage.Services
{
    public class SaveService
    {

        private EmailService emailService = new EmailService();

        public void SaveImage(IFormFile img)
        {

        }

        public void SaveText(string text, string person)
        {

        }

        public async Task SaveEmail(string name, string email)
        {
            string eMail = name + ";" + email + ",\n";
            await File.AppendAllTextAsync("Persistence/Email.txt", eMail);

            string message = "Hej " + name + "\n You are now subscribed to our newsletter";
            string subject = "Thanks for subscribing to our newsletter";
            await emailService.SendEmail(email, name, message, subject);
        }

    }
}
