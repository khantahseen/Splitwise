using AutoMapper;
using Splitwise.DomainModel;
using Splitwise.DomainModel.ApplicationClasses;
using Splitwise.DomainModel.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Splitwise.Repository.ExpenseRepository
{
    public class ExpenseRepository : IExpenseRepository
    {
        private SplitwiseDbContext _context;
        private readonly IMapper _mapper;
       
        public ExpenseRepository(SplitwiseDbContext _context, IMapper _mapper)
        {
            this._mapper = _mapper;
            this._context = _context;
        }
        public void CreateExpense(Expenses Expense)
        {
            _context.Add(Expense);
            //throw new NotImplementedException();
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
            return _context.Expenses.Any(e => e.Id == id);
            // throw new NotImplementedException();
        }

        public async Task<ExpensesAC> GetExpense(int id)
        {

            return _mapper.Map<ExpensesAC>(await _context.FindAsync<Expenses>(id));
            // throw new NotImplementedException();
        }
        public async Task Save()
        {
            await _context.SaveChangesAsync();
            //throw new NotImplementedException();
        }

        public void UpdateExpense(Expenses Expense)
        {
            throw new NotImplementedException();
        }
    }
}
