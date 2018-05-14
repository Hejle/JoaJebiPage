using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using JoaJebiPage.Services;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace JoaJebiPage.Pages
{
    public class GalleryPageModel : PageModel
    {
        private GetService getService = GetService.Instance;

        public void OnGet()
        { 
        }

        public string[] GetImages()
        {
            return getService.GetImages("/gallery");
        }
    }
}