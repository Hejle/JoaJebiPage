using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;

namespace JoaJebiPage.Services
{
    public class GetService
    {

        public string GetAboutMe(string who)
        {
            return "";
        }

        public string[] GetImages(string folder)
        {
            string path = "wwwroot/images" + folder;
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
