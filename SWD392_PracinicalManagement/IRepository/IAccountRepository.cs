﻿using SWD392_PracinicalManagement.Models;

namespace SWD392_PracinicalManagement.IRepository
{
    public interface IAccountRepository
    {
        Account? GetAccountByEmailPassword(string email, string password);
        bool UpdateAccountInfo(Account account);
    }
}
