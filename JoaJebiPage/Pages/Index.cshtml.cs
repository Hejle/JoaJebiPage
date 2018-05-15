using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace JoaJebiPage.Pages
{
    public class IndexModel : PageModel
    {

        public string WelcomeMessage { get; set; }
        public string SDUNames { get; set; }
        public string FinalMessage { get; set; }

        public void OnGet()
        {
            WelcomeMessage = "Welcome to Jebisan's and Joachim's webpage.";

            SDUNames = "Jebisan's SDU name is: jenad14 and Joachim's SDU name is johej15";

            FinalMessage = "Have fun looking around :)";
        }
    }
}
