using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using SWD392_PracinicalManagement.Util;

namespace SWD392_PracinicalManagement.Pages
{
    public class LogoutModel : PageModel
    {
        public IActionResult OnGet()
        {
            HttpContext.Session.Remove(Constant.LOGIN_ACCOUNT_SESSION_NAME);
            return RedirectToPage("/Index");
        }
    }
}
