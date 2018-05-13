using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
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




      
        public void OnGet()
        {

            /*
			FirstName = "Joachim";
			LastName = "Hejlesen";
			Birthday = "11. Januar 1995";
			Description = "Jeg er en fed idiot.";
			Picture = "images/ProfilePictures/Joachim.jpg";
*/

            

            FirstName = "Jebisan";
            LastName = "Nadarajah";
            Birthday = "8. Januar 1995";
            Description = "Jeg er faktisk cool nok.";
            Picture = "images/ProfilePictures/Jebisan.jpg";

            
        }
    }
}
