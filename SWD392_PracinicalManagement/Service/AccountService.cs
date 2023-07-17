using SWD392_PracinicalManagement.DataAccess.Models;
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
    }
}
