using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using SWD392_PracinicalManagement.Util;

namespace SWD392_PracinicalManagement.Pages.PracinicalCategory
{
    public class UpdateModel : PageModelBase
    {   
        public UpdateModel()
        {
            authorizedRoles = new string[] { Constant.MANAGER_ROLE };
        }
        public IActionResult OnGet()
        {
            if (!HasAuthorized())
            {
                return LoginBasedFeatureRedirect();
            }

            return Page();
        }
    }
}
