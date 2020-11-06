using AutoMapper;
using Microsoft.EntityFrameworkCore;
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
        }

        public IEnumerable<ExpensesAC> GetExpenses()
        {
            return _mapper.Map<IEnumerable<ExpensesAC>>(_context.Expenses);
        }

        public IEnumerable<ExpensesAC> GetExpensesByGroupId(int id)
        {
            return _mapper.Map<IEnumerable<ExpensesAC>>(_context.Expenses.Include(u=>u.User).Where(i => i.GroupId == id).ToList());
        }
        public async Task DeleteExpense(int id)
        {
            //expense
            var expenseDel = _context.Expenses.Find(id);
            _context.Expenses.Remove(expenseDel);

            //payers
            IEnumerable<Payers> payer = _context.Payers.Where(p => p.ExpenseId == id);
            _context.Payers.RemoveRange(payer);

            //payees
            IEnumerable<Payees> payee = _context.Payees.Where(pa => pa.ExpenseId == id);
            _context.Payees.RemoveRange(payee);
            await Save();
         }


        public bool ExpenseExists(int id)
        {
            return _context.Expenses.Any(e => e.Id == id);
        }

        public async Task<ExpensesAC> GetExpense(int id)
        {
            return _mapper.Map<ExpensesAC>(await _context.Expenses.Where(e=>e.Id==id).Include(u=>u.User).SingleOrDefaultAsync());
        }
        public async Task Save()
        {
            await _context.SaveChangesAsync();
        }

        public async Task UpdateExpense(Expenses Expense)
        {
            var expense = _context.Expenses.Where(e => e.Id == Expense.Id).FirstOrDefault();
            expense.Description = Expense.Description;
            expense.Currency = Expense.Currency;
            expense.Total = Expense.Total;
            expense.SplitBy = Expense.SplitBy;
            _context.Expenses.Update(expense);
            await _context.SaveChangesAsync();
        }

      
    }
}
