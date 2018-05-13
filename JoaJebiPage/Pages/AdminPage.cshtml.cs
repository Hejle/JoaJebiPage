using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Html;
using Microsoft.AspNetCore.Http;

namespace JoaJebiPage.Pages
{
    public class AdminPageModel : PageModel
    {

        [Required]
        [BindProperty]
        public string TextUpload { get; set; }

        [Required]
        [BindProperty]
        public string Who { get; set; }

        public void OnGet()
        { 
        }

        public async Task OnPostAsyncEditAbout()
        {
            if (Who.Equals("Joachim"))
            {
                Debug.WriteLine("Joachim");
                Debug.WriteLine(TextUpload);
            }
            else if (Who.Equals("Jebisan"))
            {
                Debug.WriteLine("Jebisan");
                Debug.WriteLine(TextUpload);
            }
        }

        public HtmlString GetText()
        {
            return new HtmlString(TextUpload);
        }

        [Required]
        [Display(Name = "Picture")]
        [BindProperty]
        public IFormFile FileUpload { get; set; }

        public async Task OnPostAsyncImageUpload()
        {
            if (FileUpload != null)
            {
                var filePath = "wwwroot/images/galary";
                string fileName = FileUpload.FileName;
                string fullName = Path.Combine(filePath, Guid.NewGuid().ToString() + "." + fileName);
                using (var fileStream = new FileStream(fullName, FileMode.Create))
                {
                    await FileUpload.CopyToAsync(fileStream);
                }
            }
        }
    }
}