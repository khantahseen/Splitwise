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

namespace Splitwise.Repository.SettlementRepository
{
    public class SettlementRepository : ISettlementRepository
    {
        private SplitwiseDbContext _context;
        private readonly IMapper _mapper;

        public SettlementRepository(SplitwiseDbContext _context, IMapper _mapper)
        {
            this._mapper = _mapper;
            this._context = _context;
        }
        public void CreateSettlement(Settlements Settlement)
        {
            _context.Add(Settlement);
            //throw new NotImplementedException();
        }

        public Task<SettlementsAC> GetSettlement(int id)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<SettlementsAC> GetSettlements()
        {
            return _mapper.Map<IEnumerable<SettlementsAC>>(_context.Settlements.Include(p => p.Payee).Include(l => l.Payer));
            //throw new NotImplementedException();
        }

        public IEnumerable<SettlementsAC> GetSettlementsByGroupId(int id)
        {
            return _mapper.Map<IEnumerable<SettlementsAC>>(_context.Settlements.Include(p => p.Payee)
                .Include(l => l.Payer).Where(s => s.GroupId == id).ToList());
            //throw new NotImplementedException();
        }

        public IEnumerable<SettlementsAC> GetSettlementsByUserId(string id)
        {
            throw new NotImplementedException();
        }

        public async Task Save()
        {
            await _context.SaveChangesAsync();
            //throw new NotImplementedException();
        }

        public bool SettlementExists(int id)
        {
            return _context.Settlements.Any(e => e.Id == id);
            //throw new NotImplementedException();
        }

    }
}
