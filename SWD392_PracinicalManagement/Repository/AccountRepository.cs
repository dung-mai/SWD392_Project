using Microsoft.EntityFrameworkCore;
using SWD392_PracinicalManagement.DataAccess.Models;
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
    }
}
