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
            //throw new NotImplementedException();
        }
        public IEnumerable<PayersAC> GetPayers()
        {
            return _mapper.Map<IEnumerable<PayersAC>>(_context.Payers.Include(t => t.User));
            //throw new NotImplementedException();
        }

        public IEnumerable<PayersAC> GetPayersByExpenseId(int id)
        {
            return _mapper.Map<IEnumerable<PayersAC>>(_context.Payers.Include(t => t.User).Where(e => e.ExpenseId == id).ToList());
            //throw new NotImplementedException();
        }

        public IEnumerable<PayersAC> GetPayersByPayerId(string id)
        {
            return _mapper.Map<IEnumerable<PayersAC>>(_context.Payers.Include(t => t.User).Where(e => e.PayerId == id).ToList());
            //throw new NotImplementedException();
        }

        public bool PayerExists(int id)
        {
            return _context.Payers.Any(e => e.Id == id);
            //throw new NotImplementedException();
        }

        public async Task Save()
        {
            await _context.SaveChangesAsync();
            //throw new NotImplementedException();
        }

        public Task DeletePayer(PayersAC Payer)
        {
            throw new NotImplementedException();
        }

        public Task<PayersAC> GetPayer(int id)
        {
            throw new NotImplementedException();
        }


    }
}
