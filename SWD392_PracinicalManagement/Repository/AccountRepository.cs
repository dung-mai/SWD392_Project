using Microsoft.EntityFrameworkCore;
using SWD392_PracinicalManagement.Models;
using SWD392_PracinicalManagement.IRepository;

namespace SWD392_PracinicalManagement.Repository
{
    public class AccountRepository : IAccountRepository
    {
        private SWD392_FinalProjectContext _context;

        public AccountRepository(SWD392_FinalProjectContext context)
        {
            _context = context;
        }

        public Account? GetAccountByEmailPassword(string email, string password)
        {
            return _context.Accounts
                .Include(acc => acc.Role)
                .FirstOrDefault(acc => acc.Email == email && acc.Password == password);
        }

        public bool UpdateAccountInfo(Account account)
        {
            Account? updateAccount =  _context.Accounts
                .Include(acc => acc.Role)
                .FirstOrDefault(acc => acc.AccountId == account.AccountId);

            if(updateAccount == null)
            {
                return false;
            }

            updateAccount.Name = account.Name;
            updateAccount.PhoneNumber = account.PhoneNumber;
            updateAccount.Address = account.Address;
            updateAccount.Gender = account.Gender;
            updateAccount.Dob = account.Dob;
            _context.SaveChanges();
            return true;
        }
    }
}
