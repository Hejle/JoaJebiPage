using System;
using System.IO;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Diagnostics.Views;
using Microsoft.AspNetCore.Http;

namespace JoaJebiPage.Services
{
    public class SaveService
    {

        private static SaveService instance;

        private SaveService() { }

        public static SaveService Instance
        {
            get
            {
                if (instance == null)
                {
                    instance = new SaveService();
                }
                return instance;
            }
        }

        public async Task SaveAboutText(PersonEnum.Person person, Dictionary<string, string> dictionary)
        {
            StringBuilder sb = new StringBuilder();
            foreach (var key in dictionary.Keys)
            {
                sb.Append(key + "=" + dictionary[key] + "\n");
            }

            try
            {
                await File.WriteAllTextAsync("Persistence/" + person + "/About.txt", sb.ToString());
            }
            catch (IOException e)
            {
                Console.WriteLine(e);
            }
            
        }

        private EmailService emailService = EmailService.Instance;

        public async Task SaveImage(IFormFile img)
        {
            try
            {
                var filePath = "wwwroot/images/gallery";
                string fileName = img.FileName;
                string fullName = Path.Combine(filePath, Guid.NewGuid().ToString() + "." + fileName);
                using (var fileStream = new FileStream(fullName, FileMode.Create))
                {
                    await img.CopyToAsync(fileStream);
                }
            }
            catch (IOException e)
            {
                Console.WriteLine(e);
            }
        }


        public async Task SaveEmail(string name, string email)
        {
            string eMail = name + ";" + email + ",\n";
            try
            {
                await File.AppendAllTextAsync("Persistence/Email.txt", eMail);
            }
            catch (IOException e)
            {
                Console.WriteLine(e);
            }
            string message = "Hej " + name + "\nYou are now subscribed to our newsletter";
            string subject = "Thanks for subscribing to our newsletter";
            await emailService.SendEmail(email, name, message, subject);
        }

    }
}
