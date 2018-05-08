using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace JoaJebiPage.Pages
{
    public class UploadImageModel : PageModel
    {
        public void OnGet()
        {

        }

        [Required]
        [Display(Name = "Picture")]
        [BindProperty]
        public IFormFile FileUpload { get; set; }

        public async Task OnPostAsync()
        {
            var filePath = "wwwroot/images";
            string fullName = Path.Combine(filePath, Guid.NewGuid().ToString());
            using (var fileStream = new FileStream(fullName, FileMode.Create))
            {
                await FileUpload.CopyToAsync(fileStream);
            }
        }
    }
}