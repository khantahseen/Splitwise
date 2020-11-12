using AutoMapper;
using Microsoft.EntityFrameworkCore;
using Splitwise.DomainModel;
using Splitwise.DomainModel.ApplicationClasses;
using Splitwise.DomainModel.Models;
using Splitwise.Repository.PayeeRepository;
using Splitwise.Repository.PayerRepository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Splitwise.Repository.SettlementRepository
{
    public class SettlementRepository : ISettlementRepository
    {
        #region Private Variables
        private SplitwiseDbContext _context;
        private readonly IMapper _mapper;
        private readonly IPayerRepository _payerRepository;
        private readonly IPayeeRepository _payeeRepository;
        #endregion

        #region Constructors
        public SettlementRepository(SplitwiseDbContext _context, IMapper _mapper, IPayerRepository _payerRepository, IPayeeRepository _payeeRepository)
        {
            this._mapper = _mapper;
            this._context = _context;
            this._payerRepository = _payerRepository;
            this._payeeRepository = _payeeRepository;
        }
        #endregion

        #region Public Methods
        public async Task CreateSettlement(Settlements settlement)
        {
            _context.Add(settlement);
           var payerToUpdate = this._context.Payers.Where(e => (e.ExpenseId == settlement.ExpenseId) && (e.PayerId == settlement.PayeeId))
               .FirstOrDefault();
            payerToUpdate.PayerShare = payerToUpdate.PayerShare + settlement.Amount;
            
            await this._payerRepository.UpdatePayer(settlement.PayeeId, settlement.ExpenseId, payerToUpdate);
            var payeeToUpdate = this._context.Payees.Where(e => (e.ExpenseId == settlement.ExpenseId) && (e.PayeeId == settlement.PayerId))
                .FirstOrDefault();
            payeeToUpdate.PayeeShare = payeeToUpdate.PayeeShare - settlement.Amount;
           
            await this._payeeRepository.UpdatePayee(settlement.PayerId, settlement.ExpenseId, payeeToUpdate);
            await _context.SaveChangesAsync();
        }

        public Task<SettlementsAC> GetSettlement(int id)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<SettlementsAC> GetSettlements()
        {
            return _mapper.Map<IEnumerable<SettlementsAC>>(_context.Settlements.Include(p => p.Payee).Include(l => l.Payer));
        }

        public IEnumerable<SettlementsAC> GetSettlementsByGroupId(int id)
        {
            return _mapper.Map<IEnumerable<SettlementsAC>>(_context.Settlements.Include(p => p.Payee)
                .Include(l => l.Payer).Include(g=>g.Group).Where(s => s.GroupId == id).ToList());
        }

        public IEnumerable<SettlementsAC> GetSettlementsByUserId(string id)
        {
            throw new NotImplementedException();
        }

        public async Task Save()
        {
            await _context.SaveChangesAsync();
        }

        public bool SettlementExists(int id)
        {
            return _context.Settlements.Any(e => e.Id == id);
        }
        #endregion
    }
}
