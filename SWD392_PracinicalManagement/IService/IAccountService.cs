using SWD392_PracinicalManagement.DataAccess.Models;

namespace SWD392_PracinicalManagement.IService
{
    public interface IAccountService
    {
        Account? CheckLoginAccount(string? email, string? password);
    }
}
