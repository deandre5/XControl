using proyecto_finanzas.data.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace proyecto_finanzas.data.Repositories
{
    public interface ITransactionsRepositorie
    {
        Task<string> createExpensesIncome(ExpensesIncome expensesIncome);
        Task<string> deleteExpensesIncome(int idAccount, int idExpensesIncome);
        Task<List<ExpensesIncomeResponse>> getExpensesIncome(string idCuenta, string fechaInicial, string fechaFinal);
        Task<string> updateExpensesIncome(ExpensesIncome expensesIncome);
    }
}
