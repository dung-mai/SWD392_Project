using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using SWD392_PracinicalManagement.Models;
using SWD392_PracinicalManagement.Extensions;

namespace SWD392_PracinicalManagement.Util
{
    public class PageModelBase : PageModel
    {
        public Account? LoggedInAccount { get; set; }
        public string[] authorizedRoles = new string[]{ };

        public PageModelBase()
        {
        
        }

        private IActionResult DefaultPageByRole(Account account)
        {
            if (account.Role?.RoleName?.ToLower() == Constant.PATIENT_ROLE)
            {
                return RedirectToPage(Constant.DEFAULT_PATIENT_PAGE);
            }
            else
            {
                return RedirectToPage(Constant.DEFAULT_MANAGE_PAGE);
            }
        }

        public bool HasAuthorized()
        {
            LoggedInAccount = HttpContext.Session.Get<Account>(Constant.LOGIN_ACCOUNT_SESSION_NAME);

            //NOT LOGIN + GUEST can acess --> true
            if (LoggedInAccount is null) 
            {
                if (IsGuestFeature()) 
                {
                    return true;
                }
            }
            //HAS LOGIN + check role
            else
            {
                foreach (string r in authorizedRoles)
                {
                    if (r == LoggedInAccount?.Role?.RoleName)
                    {
                        return true;
                    }
                }
            }
            return false;
        }

        public IActionResult LoginBasedFeatureRedirect()
        {
            if (LoggedInAccount is null)
            {
                return RedirectToPage("/Login");
            }
            else
            {
                return DefaultPageByRole(LoggedInAccount);
            }
        }

        private bool IsGuestFeature()
        {
            foreach(string role in authorizedRoles)
            {
                if(role == Constant.GUEST)
                {
                    return true;
                }
            }
            return false;
        }
    }
}
