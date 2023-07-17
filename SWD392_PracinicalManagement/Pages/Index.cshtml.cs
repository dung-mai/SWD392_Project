using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using SWD392_PracinicalManagement.Util;

namespace SWD392_PracinicalManagement.Pages
{
    public class IndexModel : PageModelBase
    {
        private readonly ILogger<IndexModel> _logger;

        public IndexModel(ILogger<IndexModel> logger)
        {
            _logger = logger;
            authorizedRoles = new string[] { "guest", "patient" };
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