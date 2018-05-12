using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace JoaJebiPage.Pages
{
    public class AdminPageModel : PageModel
    {

        [Required]
        [BindProperty]
        public string TextUpload { get; set; }

        public void OnGet()
        {

        }

        public async Task OnPostAsync()
        {
            if (TextUpload != null)
            {
                
            }
        }
    }
}