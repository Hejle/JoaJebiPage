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


		[Required]
		[BindProperty]
		public string TextUpload { get; set; }

		[Required]
		[BindProperty]
		public PersonEnum.Person Who { get; set; }

		public void OnGet()
		{
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