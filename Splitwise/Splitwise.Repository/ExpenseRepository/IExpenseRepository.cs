using Splitwise.DomainModel.ApplicationClasses;
using Splitwise.DomainModel.Models;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Splitwise.Repository.ExpenseRepository
{
    public interface IExpenseRepository
    {
        IEnumerable<ExpensesAC> GetExpenses();
        Task<ExpensesAC> GetExpense(int id);
        IEnumerable<ExpensesAC> GetExpensesByGroupId(int id);
        void CreateExpense(Expenses Expense);
        Task UpdateExpense(Expenses Expense);
        Task DeleteExpense(int id);
        bool ExpenseExists(int id);
        Task Save();
    }
}
