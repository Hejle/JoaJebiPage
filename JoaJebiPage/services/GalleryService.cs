using System;
using System.Collections.Generic;
using System.IO;

namespace JoaJebiPage.services
{
    public class GalleryService
    {
        public List<String> ImagePathList;

        public List<String> getImagePath()
        {
            string path = "wwwroot/images/galary";
            foreach (var imageFile in Directory.GetFiles(path))
            {
                string s = imageFile.Substring(path.Length);
                string d = s.Substring(1);
                string final = path + "/" + d;
                Console.WriteLine(final);
            }
            return ImagePathList;
        }
    }
}
