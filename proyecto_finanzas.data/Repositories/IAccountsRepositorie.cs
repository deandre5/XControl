using proyecto_finanzas.data.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace proyecto_finanzas.data.Repositories
{
    public interface IAccountsRepositorie
    {
        Task<string> createAccount(AccountsDTO cuenta);
        Task<string> deleteAccount(int idAccount, int idUser);
        Task<List<AccountsResponseDTO>> getAccounts(string idUser);
        Task<string> updateAccount(AccountsDTO account);
    }
}
