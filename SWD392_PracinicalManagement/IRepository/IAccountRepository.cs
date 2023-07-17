using SWD392_PracinicalManagement.DataAccess.Models;

namespace SWD392_PracinicalManagement.IRepository
{
    public interface IAccountRepository
    {
        Account? GetAccountByEmailPassword(string email, string password);
    }
}
