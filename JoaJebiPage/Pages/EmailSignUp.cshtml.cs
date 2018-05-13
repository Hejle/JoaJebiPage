using System.ComponentModel.DataAnnotations;
using System.Diagnostics;
using System.Net.Mail;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace JoaJebiPage.Pages
{
    public class EmailSignUpModel : PageModel
    {
        private string password = "JoaJebi1";
        
        [Required]
        [BindProperty]
        public string NameUpload { get; set; }

        [Required]
        [BindProperty]
        public string EMailUpload { get; set; }

        public void OnGet()
        {
            NameUpload = "TestString";
        }

        public async void OnPostEmail()
        {
            if ((EMailUpload != null) & (NameUpload != null))
            {
                Debug.WriteLine(EMailUpload + " " + NameUpload);
                await SendEmail();
            }
        }

        private async Task SendEmail()
        {
            MailMessage message = new MailMessage();
            message.To.Add(EMailUpload);
            message.Subject = "This is the Subject line";
            message.From = new System.Net.Mail.MailAddress("internettechnology2018@hotmail.com");
            message.Body = "Hej " + NameUpload + "\n This is the message body";
            SmtpClient SmtpServer = new SmtpClient("smtp.live.com");
            SmtpServer.Port = 587;
            SmtpServer.Credentials = new System.Net.NetworkCredential("internettechnology2018@hotmail.com", password);
            SmtpServer.EnableSsl = true;
            await SmtpServer.SendMailAsync(message);
        }

        public string GetText()
        {
            if ((EMailUpload != null) & (NameUpload != null))
            {
                return NameUpload + " har denne EMail: " + EMailUpload;
            }
            return "";
        }
    }
}