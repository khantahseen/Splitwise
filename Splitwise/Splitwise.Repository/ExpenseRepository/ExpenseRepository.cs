using Splitwise.DomainModel.ApplicationClasses;
using Splitwise.DomainModel.Models;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Splitwise.Repository.ExpenseRepository
{
    public class ExpenseRepository : IExpenseRepository
    {
        public void CreateExpense(Expenses Expense)
        {
            throw new NotImplementedException();
        }

        public Task DeleteExpense(ExpensesAC Expense)
        {
            throw new NotImplementedException();
        }

        public Task DeleteExpensesByGroupId(int id)
        {
            throw new NotImplementedException();
        }

        public bool ExpenseExists(int id)
        {
            throw new NotImplementedException();
        }

        public Task<ExpensesAC> GetExpense(int id)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<ExpensesAC> GetExpenses()
        {
            throw new NotImplementedException();
        }

        public Task Save()
        {
            throw new NotImplementedException();
        }

        public void UpdateExpense(Expenses Expense)
        {
            throw new NotImplementedException();
        }
    }
}
