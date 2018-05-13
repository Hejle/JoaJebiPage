using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using JoaJebiPage.Services;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Html;
using Microsoft.AspNetCore.Http;

namespace JoaJebiPage.Pages
{
    public class AdminPageModel : PageModel
    {
        private SaveService saveService = new SaveService();


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
        public IFormFile ImageUpload { get; set; }

        public async Task OnPostAsyncImageUpload()
        { 
            if (ImageUpload != null)  
            {
<<<<<<< HEAD
                await saveService.SaveImage(ImageUpload);
=======
                var filePath = "wwwroot/images/gallery";
                string fileName = FileUpload.FileName;
                string fullName = Path.Combine(filePath, Guid.NewGuid().ToString() + "." + fileName);
                using (var fileStream = new FileStream(fullName, FileMode.Create))
                {
                    await FileUpload.CopyToAsync(fileStream);
                }
>>>>>>> 89527ab... Fixed "galary"
            }
        }
    }
}