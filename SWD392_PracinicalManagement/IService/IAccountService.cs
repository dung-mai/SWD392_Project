using SWD392_PracinicalManagement.Models;

namespace SWD392_PracinicalManagement.IService
{
    public interface IAccountService
    {
        Account? CheckLoginAccount(string? email, string? password);
    }
}
