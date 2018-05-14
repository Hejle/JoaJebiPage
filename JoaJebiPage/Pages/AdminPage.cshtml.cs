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
	    [Required]
	    [BindProperty]
        public string LastName { get; set; }
	    [Required]
	    [BindProperty]
        public string Birthday { get; set; }
	    [Required]
	    [BindProperty]
        public string Description { get; set; }
	    [Required]
	    [BindProperty]
        public string Picture { get; set; }
		[Required]
		[BindProperty]
		public PersonEnum.Person Who { get; set; }
	    [Required]
	    [BindProperty]
	    public IFormFile ImageUpload { get; set; }

        public async void OnPostInformationAsync()
        {
            var dictionary = getService.LoadPersonData(Who);
            dictionary["firstname"] = FirstName;
            dictionary["lastname"] = LastName;
            dictionary["date"] = Birthday;
            dictionary["description"] = Description;
            await saveService.SaveAboutText(Who, dictionary);
		}
        

        
		public void OnGet()
		{
		    LoadPerson(Who);
		}

	    public void LoadPerson(PersonEnum.Person person)
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

		public async Task OnPostImageUploadAsync()
		{
			if (ImageUpload != null)
			{
				await saveService.SaveImage(ImageUpload);
			}
		}

	    public void OnPostAbout()
	    {
            LoadPerson(Who);
	    }

	    public PersonEnum.Person[] GetPersons()
	    {
	        PersonEnum.Person[] plist = {PersonEnum.Person.Jebisan, PersonEnum.Person.Joachim};
	        return plist;
	    }
	}
}