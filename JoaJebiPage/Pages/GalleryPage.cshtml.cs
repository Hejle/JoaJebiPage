using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace JoaJebiPage.Pages
{
    public class GalleryPageModel : PageModel
    {
        public void OnGet()
        {

        }

        public string[] GetImages()
        {
            string path = "wwwroot/images/gallery";
            var files = Directory.GetFiles(path);
            var images = new List<string>();
            foreach (var file in files)
            {
                string s = file.Replace("\\", "/").Replace("wwwroot", "");
                images.Add(s);
            }
            
            return images.ToArray();
        }
    }
}