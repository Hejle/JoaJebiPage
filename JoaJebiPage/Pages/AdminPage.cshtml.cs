using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using JoaJebiPage.Services;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Html;
using Microsoft.AspNetCore.Http;

namespace JoaJebiPage.Pages
{
	public class AdminPageModel : PageModel
	{

		private SaveService saveService = SaveService.Instance;
		private GetService getService = GetService.Instance;
      
		[Required]
        [BindProperty]
		public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Birthday { get; set; }
        public string Description { get; set; }
        public string Picture { get; set; }



		[Required]
		[BindProperty]
		public string TextUpload { get; set; }

		[Required]
		[BindProperty]
		public PersonEnum.Person Who { get; set; }

	
        
		public async void OnPostInformation(){		
			using (System.IO.StreamWriter file = new System.IO.StreamWriter("Persistence/" + Who + "/About.txt"))
                file.WriteLine(
					"firstname =" +FirstName+"\n" +
					"lastname = Hejlesen\n" +
					"date = 10.Januar 1994\n" +
					"description = Jeg er en fed idiot.\n" +
					"image = images / ProfilePictures / Joachim.jpg"
				
				);

              
		}
        

        
		public void OnGet()
		{
			var dictionary = getService.LoadPersonData(Who);

			try
            {
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
		}

		public async Task OnPostEditAboutAsync()
		{
		    await saveService.SaveAboutText(TextUpload, Who);

		}

		public HtmlString GetText()
		{
			return new HtmlString(TextUpload);
		}



		[Required]
		[Display(Name = "Picture")]
		[BindProperty]
		public IFormFile ImageUpload { get; set; }

		public async Task OnPostImageUploadAsync()
		{
			if (ImageUpload != null)
			{
				await saveService.SaveImage(ImageUpload);

			}
		}

	    public PersonEnum.Person[] GetPersons()
	    {
	        PersonEnum.Person[] plist = {PersonEnum.Person.Jebisan, PersonEnum.Person.Joachim};
	        return plist;
	    }
	}
}