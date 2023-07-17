using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using SWD392_PracinicalManagement.Util;

namespace SWD392_PracinicalManagement.Pages
{
    public class PrivacyModel : PageModelBase
    {
        public PrivacyModel()
        {
            authorizedRoles = new string[] { "manager", "doctor"};
        }

        public IActionResult OnGet()
        {
            if (!HasAuthorized())
            {
                return LoginBasedFeatureRedirect();
            }

            //XỬ LÝ CODE



            return Page();
        }
    }
}