﻿using AutoMapper;
using Microsoft.EntityFrameworkCore;
using Splitwise.DomainModel;
using Splitwise.DomainModel.ApplicationClasses;
using Splitwise.DomainModel.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Splitwise.Repository.PayeeRepository
{
    public class PayeeRepository : IPayeeRepository
    {
        #region Private Variables
        private SplitwiseDbContext _context;
        private readonly IMapper _mapper;
        #endregion

        #region Constructors
        public PayeeRepository(SplitwiseDbContext _context, IMapper _mapper)
        {
            this._context = _context;
            this._mapper = _mapper;
        }
        #endregion

        #region Public Methods
        public void CreatePayee(Payees Payee)
        {
            _context.Add(Payee);
        }

        public IEnumerable<PayeesAC> GetPayees()
        {
            return _mapper.Map<IEnumerable<PayeesAC>>(_context.Payees.Include(t => t.User));
        }

        public IEnumerable<PayeesAC> GetPayeesByExpenseId(int id)
        {
            return _mapper.Map<IEnumerable<PayeesAC>>(_context.Payees.Include(t => t.User).Where(e => e.ExpenseId == id).ToList());
        }

        public IEnumerable<PayeesAC> GetPayeesByPayeeId(string id)
        {
            return _mapper.Map<IEnumerable<PayeesAC>>(_context.Payees.Where(e => e.PayeeId == id).ToList());
        }

        public bool PayeeExists(int id)
        {
            return _context.Payees.Any(e => e.Id == id);
        }

        public async Task Save()
        {
            await _context.SaveChangesAsync();
        }

        public async Task<IEnumerable<PayeesAC>> GetExpensesByPayeeId(string payeeId)
        {
            var expenses = await this._context.Payees
                .Where(p => p.PayeeId == payeeId)
                .Include(p => p.Expense)
                .Include(p=>p.User)
                .Select(p => p)
                .ToListAsync();
            return this._mapper.Map<IEnumerable<PayeesAC>>(expenses);
        }

        public async Task UpdatePayee(string payeeid, int expenseid, Payees payee)
        {
            var payeeUpdate = this._context.Payees.Where(e => (e.PayeeId == payeeid) && (e.ExpenseId == expenseid)).FirstOrDefault();
            payeeUpdate.PayeeShare = payee.PayeeShare;
            this._context.Payees.Update(payeeUpdate);
            await _context.SaveChangesAsync();
            //throw new NotImplementedException();
        }
        #endregion
    }
}
