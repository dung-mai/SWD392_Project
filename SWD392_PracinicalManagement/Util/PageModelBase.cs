using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using SWD392_PracinicalManagement.Models;
using SWD392_PracinicalManagement.Extensions;

namespace SWD392_PracinicalManagement.Util
{
    public class PageModelBase : PageModel
    {
        public Account? LoggedInAccount { get; set; }
        private string[] authorizedRoles = new string[]{ };

        public PageModelBase() 
        { 
        
        }

        private IActionResult DefaultPageByRole(Account account)
        {
            if (account.Role?.RoleName?.ToLower() == "patient")
            {
                return RedirectToPage(Constant.DEFAULT_PATIENT_PAGE);
            }
            else
            {
                return RedirectToPage(Constant.DEFAULT_MANAGE_PAGE);
            }
        }

        private IActionResult CheckHasLogin()
        {
            Account? account = HttpContext.Session.Get<Account>("loggedInAccount");

            if (account is null)
            {
                if (IsGuestFeature()) // if guest can access
                {
                    return Page();
                } else // need login
                {
                    return RedirectToPage("/Login");
                }
            }
            else
            {
                if (HasAuthorized(account.Role.RoleName))
                {

                }
                return DefaultPageByRole(account);
            }
        }

        private bool IsGuestFeature()
        {
            foreach(string role in authorizedRoles)
            {
                if(role == "guest")
                {
                    return true;
                }
            }
            return false;
        }

        private bool HasAuthorized(string _role)
        {
            foreach (string r in authorizedRoles)
            {
                if (r == _role)
                {
                    return true;
                }
            }
            return false;
        }
    }
}
