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
        
		private GetService getService = GetService.Instance;
	      

		[BindProperty]
		public PersonEnum.Person Who { get; set; }

	    public void OnGet()
	    {
	       LoadPerson(PersonEnum.Person.Joachim);
        }

		public PersonEnum.Person[] GetPersons()
		{
			PersonEnum.Person[] personList = { PersonEnum.Person.Jebisan, PersonEnum.Person.Joachim };
			return personList;
		}

		public void OnPostAbout()
		{
			LoadPerson(Who);
		}

		private void LoadPerson(PersonEnum.Person Who)
		{
			var dictionary = getService.LoadPersonData(Who);
			try
			{
				FirstName = dictionary["firstname"];
				LastName = dictionary["lastname"];
				Birthday = dictionary["date"];
				Description = dictionary["description"];
				Picture = dictionary["image"];

				EducationTime1 = dictionary["educationtime1"];
				EducationTitle1 = dictionary["educationtitle1"];
				EducationPlace1 = dictionary["educationplace1"];
				EducationLocation1 = dictionary["educationlocation1"];

				EducationTime2 = dictionary["educationtime2"];
				EducationTitle2 = dictionary["educationtitle2"];
				EducationPlace2 = dictionary["educationplace2"];
				EducationLocation2 = dictionary["educationlocation2"];

				EducationTime3 = dictionary["educationtime3"];
				EducationTitle3 = dictionary["educationtitle3"];
				EducationPlace3 = dictionary["educationplace3"];
				EducationLocation3 = dictionary["educationlocation3"];

				WorkTime1 = dictionary["worktime1"];
				WorkTitle1 = dictionary["worktitle1"];
				WorkPlace1 = dictionary["workplace1"];
				WorkLocation1 = dictionary["worklocation1"];

				WorkTime2 = dictionary["worktime2"];
				WorkTitle2 = dictionary["worktitle2"];
				WorkPlace2 = dictionary["workplace2"];
				WorkLocation2 = dictionary["worklocation2"];
			}
			catch (KeyNotFoundException e)
			{
				Console.WriteLine(e);
			}

		}

		// Properties that is displayed in THML
		public string FirstName { get; set; } = "FirstName";
		public string LastName { get; set; } = "LastName";
		public string Birthday { get; set; } = "01. January 1900";
		public string Description { get; set; } = "Lorem ipsum dolor sit amet, consectetur adipiscing elit, sed do eiusmod tempor incididunt ut labore et dolore magna aliqua.";
		public string Picture { get; set; } = "images/ProfilePictures/defaultFace.jpg";

		public string EducationTime1 { get; set; }
		public string EducationTitle1 { get; set; }
		public string EducationPlace1 { get; set; }
		public string EducationLocation1 { get; set; }

		public string EducationTime2 { get; set; }
		public string EducationTitle2 { get; set; }
		public string EducationPlace2 { get; set; }
		public string EducationLocation2 { get; set; }

		public string EducationTime3 { get; set; }
		public string EducationTitle3 { get; set; }
		public string EducationPlace3 { get; set; }
		public string EducationLocation3 { get; set; }

		public string WorkTime1 { get; set; }
		public string WorkTitle1 { get; set; }
		public string WorkPlace1 { get; set; }
		public string WorkLocation1 { get; set; }

	    public string WorkTime2 { get; set; }
	    public string WorkTitle2 { get; set; }
	    public string WorkPlace2 { get; set; }
	    public string WorkLocation2 { get; set; }
    }
}
