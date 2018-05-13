using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Html;

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
                /*string temp = TextUpload;
                temp = temp.Replace(" ", "&nbsp;");
                temp = temp.Replace("\r\n", "<br>");
                TextUpload = temp;
                Debug.WriteLine(TextUpload); */
            }
        }

        public HtmlString GetText()
        {
            return new HtmlString(TextUpload);
        }
    }
}