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
	public class AboutModel : PageModel
	{
	    public string FirstName { get; set; } = "FirstName";
		public string LastName { get; set; } = "LastName";
        public string Birthday { get; set; } = "01. January 1900";
        public string Description { get; set; } = "Lorem ipsum dolor sit amet, consectetur adipiscing elit, sed do eiusmod tempor incididunt ut labore et dolore magna aliqua.";
        public string Picture { get; set; } = "images/ProfilePictures/defaultFace.jpg";
        [BindProperty]
	    public PersonEnum.Person Who { get; set; }
        public List<string> serialNumbers;

	    public void OnGet()
	    {
	        LoadData(PersonEnum.Person.Jebisan);
	    }

	    private void LoadData(PersonEnum.Person person)
        {
            try
            {
                string[] lines = System.IO.File.ReadAllLines("Persistence/" + person + "/About.txt");
                //Enumerable<string, int>
                //System.Linq.Enumerable
                var pairs = lines.Select(l => new {Line = l, Position = l.IndexOf("=")});
                var dictionary = pairs.ToDictionary(pair => pair.Line.Substring(0, pair.Position), p => p.Line.Substring(p.Position + 1));

                FirstName = dictionary["firstname"];
                LastName = dictionary["lastname"];
                Birthday = dictionary["date"];
                Description = dictionary["description"];
                Picture = dictionary["image"];
            }
            catch (KeyNotFoundException e)
            {
                Console.WriteLine(e);
            }
            catch (FileNotFoundException e)
            {
                Console.WriteLine(e);
            }
        }

        public PersonEnum.Person[] GetPersons()
	    {
	        PersonEnum.Person[] plist = { PersonEnum.Person.Jebisan, PersonEnum.Person.Joachim };
	        return plist;
	    }

	    public void OnPostAbout()
	    {
	        LoadData(Who);
	    }
    }
}
