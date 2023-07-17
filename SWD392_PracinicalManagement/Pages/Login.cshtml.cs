using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using SWD392_PracinicalManagement.Models;
using SWD392_PracinicalManagement.Extensions;
using SWD392_PracinicalManagement.IService;
using SWD392_PracinicalManagement.Util;

namespace SWD392_PracinicalManagement.Pages
{
    public class LoginModel : PageModel
    {
        private IAccountService _accountService;

        public LoginModel(IAccountService accountService)
        {
            _accountService = accountService;
        }

        public IActionResult OnGet()
        {
            return CheckHasLogin();
        }

        public IActionResult OnPost(string? email, string? password)
        {
            Account? account = _accountService.CheckLoginAccount(email, password);
            if (account is null)
            {
                TempData["error"] = "Vui lòng kiểm tra lại email và mật khẩu!";
                return Page();
            }
            else
            {
                account.MedicalRecords = null;
                account.Doctors = null;
                account.ExaminationForms = null;
                account.Role.Accounts = null;
                HttpContext.Session.Set<Account>("loggedInAccount", account);
                return DefaultPageByRole(account);
            }
        }

        private IActionResult DefaultPageByRole(Account account)
        {
            if(account.Role?.RoleName?.ToLower() == "patient")
            {
                return RedirectToPage(Constant.DEFAULT_PATIENT_PAGE);
            } else
            {
                return RedirectToPage(Constant.DEFAULT_MANAGE_PAGE);
            }
        }

        private IActionResult CheckHasLogin()
        {
            Account? account = HttpContext.Session.Get<Account>("loggedInAccount");

            if(account is null)
            {
                return Page();
            } else
            {
                return DefaultPageByRole(account);
            }
        }
    }
}
