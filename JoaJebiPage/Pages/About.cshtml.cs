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
		public string FirstName { get; set; }
		public string LastName { get; set; }
		public string Birthday { get; set; }
		public string Description { get; set; }
		public string Picture { get; set; }
        [BindProperty]
	    public PersonEnum.Person Who { get; set; }
        public List<string> serialNumbers;

	    public void OnGet()
	    {
	        LoadData(PersonEnum.Person.Jebisan);
	    }

	    private void LoadData(PersonEnum.Person person)
	    {
	        string information;
	        using (StreamReader reader = new StreamReader(person + ".txt"))
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

	    public PersonEnum.Person[] GetPersons()
	    {
	        PersonEnum.Person[] plist = { PersonEnum.Person.Jebisan, PersonEnum.Person.Joachim };
	        return plist;
	    }

	    public void OnPostAboutAsync()
	    {
	        LoadData(Who);
	    }
    }
}
