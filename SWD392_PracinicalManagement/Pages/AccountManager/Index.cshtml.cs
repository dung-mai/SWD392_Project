using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using SWD392_PracinicalManagement.Extensions;
using SWD392_PracinicalManagement.IService;
using SWD392_PracinicalManagement.Models;
using SWD392_PracinicalManagement.Util;
using System.Security.Principal;

namespace SWD392_PracinicalManagement.Pages.AccountManager
{
    public class IndexModel : PageModelBase
    {
        private IAccountService _accountService;
        public Account Account { get; set; }

        public IndexModel(IAccountService accountService)
        {
            _accountService = accountService;
            authorizedRoles = new string[] {"patient"};
        }

        public IActionResult OnGet()
        {
            if (!HasAuthorized())
            {
                return LoginBasedFeatureRedirect();
            }

            //XỬ LÝ CODE
            Account = new Account
            {
                Name = LoggedInAccount.Name,
                PhoneNumber = LoggedInAccount.PhoneNumber,
                Gender = LoggedInAccount.Gender,
                Address = LoggedInAccount.Address,
                Dob = LoggedInAccount.Dob
            };

            return Page();
        }

        public IActionResult OnPost(string? name, string? phonenumber, string? gender, string? address, DateTime? dob)
        {
            if (!HasAuthorized())
            {
                return LoginBasedFeatureRedirect();
            }
            //XỬ LÝ CODE
            bool result = _accountService.UpdateAccountInfo(new Account
            {
                AccountId = LoggedInAccount.AccountId,
                Name = name,
                PhoneNumber = phonenumber,
                Gender = gender,
                Address = address,
                Dob = dob
            });

            if(result)
            {
                TempData["success"] = "Cập nhật thông tin thành công";
                Account? account = _accountService.CheckLoginAccount(LoggedInAccount.Email, LoggedInAccount.Password);
                UpdateToSesssion(account);

                return Redirect("/account/update");
            } else
            {
                Account = new Account
                {
                    Name = name,
                    PhoneNumber = phonenumber,
                    Gender = gender,
                    Address = address,
                    Dob = dob
                };
                TempData["error"] = "Thông tin không hợp lệ. Vui lòng kiểm tra lại!";
                return Page();
            }

        }

        private void UpdateToSesssion(Account? account)
        {
            if(account is null)
            {
                return;
            }
            account.MedicalRecords = null;
            account.Doctors = null;
            account.ExaminationForms = null;
            account.Role.Accounts = null;
            HttpContext.Session.Set<Account>("loggedInAccount", account);
        }
    }
}
