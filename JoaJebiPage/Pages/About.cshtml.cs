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
	        /*LoadData(PersonEnum.Person.Jebisan);

	        FirstName = dictionary["firstname"];
	        LastName = dictionary["lastname"];
	        Birthday = dictionary["date"];
	        Description = dictionary["description"];
	        Picture = dictionary["image"];*/
        }

	    

        public PersonEnum.Person[] GetPersons()
	    {
	        PersonEnum.Person[] personList = { PersonEnum.Person.Jebisan, PersonEnum.Person.Joachim };
	        return personList;
	    }

	    public void OnPostAbout()
	    {
	        //LoadData(Who);
	    }
    }
}
