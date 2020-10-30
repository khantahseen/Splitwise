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

namespace Splitwise.Repository.PayeeRepository
{
    public class PayeeRepository : IPayeeRepository
    {
        private SplitwiseDbContext _context;
        private readonly IMapper _mapper;

        public PayeeRepository(SplitwiseDbContext _context, IMapper _mapper)
        {
            this._context = _context;
            this._mapper = _mapper;

        }
        public void CreatePayee(Payees Payee)
        {
            _context.Add(Payee);

            //throw new NotImplementedException();
        }

        public IEnumerable<PayeesAC> GetPayees()
        {
            return _mapper.Map<IEnumerable<PayeesAC>>(_context.Payees.Include(t => t.User));
            //throw new NotImplementedException();
        }

        public IEnumerable<PayeesAC> GetPayeesByExpenseId(int id)
        {
            return _mapper.Map<IEnumerable<PayeesAC>>(_context.Payees.Include(t => t.User).Where(e => e.ExpenseId == id).ToList());
            //throw new NotImplementedException();
        }

        public IEnumerable<PayeesAC> GetPayeesByPayeeId(string id)
        {
            return _mapper.Map<IEnumerable<PayeesAC>>(_context.Payees.Where(e => e.PayeeId == id).ToList());
            //throw new NotImplementedException();
        }

        public bool PayeeExists(int id)
        {
            return _context.Payees.Any(e => e.Id == id);
            //throw new NotImplementedException();
        }

        public async Task Save()
        {
            await _context.SaveChangesAsync();
            //throw new NotImplementedException();
        }
    }
}
