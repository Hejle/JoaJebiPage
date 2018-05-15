using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.AspNetCore.HttpOverrides;

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

        /**
         * Code from https://stackoverflow.com/a/34176522
         */
        public Dictionary<string, string> LoadPersonData(PersonEnum.Person person)
        {
            var dictionary = new Dictionary<string, string>();
            try
            {
                string[] lines = File.ReadAllLines("Persistence/" + person + "/About.txt", Encoding.UTF8);
                var pairs = lines.Select(l => new { Line = l, Position = l.IndexOf("=") });
                dictionary = pairs.ToDictionary(pair => pair.Line.Substring(0, pair.Position),
                    p => p.Line.Substring(p.Position + 1));
            }
            catch (IOException e)
            {
                Console.WriteLine(e);
            }
            return dictionary;
        }

        public string[] GetImages(string folder)
        {
            var images = new List<string>();
            try
            {
                string path = "wwwroot/images" + folder;
                var files = Directory.GetFiles(path);
                foreach (var file in files)
                {
                    string s = file.Replace("\\", "/").Replace("wwwroot", "");
                    images.Add(s);
                }
            }
            catch (IOException e)
            {
                Console.WriteLine(e);
            }
            return images.ToArray();
        }
    }
}
