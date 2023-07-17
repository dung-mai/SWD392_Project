using SWD392_PracinicalManagement.Models;
using SWD392_PracinicalManagement.IRepository;
using SWD392_PracinicalManagement.IService;

namespace SWD392_PracinicalManagement.Service
{
    public class AccountService : IAccountService
    {
        private IAccountRepository _accountRepository;

        public AccountService(IAccountRepository accountRepository)
        {
            _accountRepository = accountRepository;
        }

        public Account? CheckLoginAccount(string? email, string? password)
        {
            if(String.IsNullOrEmpty(email) || String.IsNullOrEmpty(password))
            {
                return null;
            } else
            {
                return _accountRepository.GetAccountByEmailPassword(email, password);
            }
        }

        public bool UpdateAccountInfo(Account account)
        {
            if(String.IsNullOrEmpty(account.Address) || String.IsNullOrEmpty(account.PhoneNumber)
                                                   || String.IsNullOrEmpty(account.Name)
                                                   || String.IsNullOrEmpty(account.Gender)
                                                   || String.IsNullOrEmpty(account.Dob?.ToString())) {
                return false;
            } else
            {
                return _accountRepository.UpdateAccountInfo(account);
            }
        }
    }
}
