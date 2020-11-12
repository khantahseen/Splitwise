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

namespace Splitwise.Repository.PayerRepository
{
    public class PayerRepository : IPayerRepository
    {
        private SplitwiseDbContext _context;
        private readonly IMapper _mapper;
      
        public PayerRepository(SplitwiseDbContext _context, IMapper _mapper)
        {
            this._context = _context;
            this._mapper = _mapper;
          
        }
        public void CreatePayer(Payers Payer)
        {
            _context.Add(Payer);
        }
        public IEnumerable<PayersAC> GetPayers()
        {
            return _mapper.Map<IEnumerable<PayersAC>>(_context.Payers.Include(t => t.User));
        }

        public IEnumerable<PayersAC> GetPayersByExpenseId(int id)
        {
            return _mapper.Map<IEnumerable<PayersAC>>(_context.Payers.Include(t => t.User).Where(e => e.ExpenseId == id).ToList());
        }

        public IEnumerable<PayersAC> GetPayersByPayerId(string id)
        {
            return _mapper.Map<IEnumerable<PayersAC>>(_context.Payers.Include(t => t.User).Where(e => e.PayerId == id).ToList());
        }

        public bool PayerExists(int id)
        {
            return _context.Payers.Any(e => e.Id == id);
        }

        public async Task Save()
        {
            await _context.SaveChangesAsync();
        }

        public Task DeletePayer(PayersAC Payer)
        {
            throw new NotImplementedException();
        }

        public async Task<PayersAC> GetPayer(int id)
        {
            return _mapper.Map<PayersAC>(await _context.Payers.FindAsync(id));
        }

        public async Task<IEnumerable<PayersAC>> GetExpensesByPayerId(string payerId)
        {
            var expenses = await this._context.Payers
                .Where(p => p.PayerId == payerId)
                .Include(p => p.Expense)
                .Include(p=>p.User)
                .Select(p => p)
                .ToListAsync();
            return this._mapper.Map<IEnumerable<PayersAC>>(expenses);
        }

        public async Task UpdatePayer(string payerId, int expenseId, Payers payer)
        {
            var payerUpdate = this._context.Payers.Where(e => (e.PayerId == payerId) && (e.ExpenseId == expenseId)).FirstOrDefault();
            payerUpdate.AmountPaid = payer.AmountPaid;
            payerUpdate.PayerShare = payer.PayerShare;
            this._context.Payers.Update(payerUpdate);
            await _context.SaveChangesAsync();
        }
    }
}
