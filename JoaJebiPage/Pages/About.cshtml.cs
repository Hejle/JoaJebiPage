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

	    private void LoadData1(PersonEnum.Person person)
	    {
	        string information;
	        using (StreamReader reader = new StreamReader("Persistence/" +person + "About.txt"))
	        {
	            information = reader.ReadLine();
	        }

	        string[] splittedWords = information.Split(new Char[] { ',' });

	        FirstName = splittedWords[0];
	        LastName = splittedWords[1];
	        Birthday = splittedWords[2];
	        Description = splittedWords[3];
	        Picture = splittedWords[4];
        }

	    private void LoadData(PersonEnum.Person person)
        {
            try
            {
                string[] lines = System.IO.File.ReadAllLines("Persistence/" + person + "/About.txt");

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
