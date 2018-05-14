using System.ComponentModel.DataAnnotations;
using System.Diagnostics;
using System.Net.Mail;
using System.Threading.Tasks;
using JoaJebiPage.Services;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace JoaJebiPage.Pages
{
    public class EmailSignUpModel : PageModel
    {
        private SaveService saveService = SaveService.Instance;


        [Required]
        [BindProperty]
        public string NameUpload { get; set; }

        [Required]
        [BindProperty]
        public string EMailUpload { get; set; }

        public void OnGet()
        {
        }

        public async void OnPostEmail()
        {
            if ((EMailUpload != null) & (NameUpload != null))
            {
                await saveService.SaveEmail(NameUpload, EMailUpload);
            }
        }
    }
}