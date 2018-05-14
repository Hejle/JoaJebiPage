using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;

namespace JoaJebiPage.Services
{
    public class GetService
    {

        private static GetService instance;

        private GetService() { }

        public static GetService Instance
        {
            get
            {
                if (instance == null)
                {
                    instance = new GetService();
                }
                return instance;
            }
        }

        public Dictionary<string, string> LoadPersonData(PersonEnum.Person person)
        {
            var dictionary = new Dictionary<string, string>();
            try
            {
                string[] lines = System.IO.File.ReadAllLines("Persistence/" + person + "/About.txt");

                var pairs = lines.Select(l => new { Line = l, Position = l.IndexOf("=") });
                dictionary = pairs.ToDictionary(pair => pair.Line.Substring(0, pair.Position),
                    p => p.Line.Substring(p.Position + 1));
            }
            catch (FileNotFoundException e)
            {
                Console.WriteLine(e);
            }
            return dictionary;
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
