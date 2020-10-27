using Splitwise.DomainModel.ApplicationClasses;
using Splitwise.DomainModel.Models;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Splitwise.Repository.SettlementRepository
{
    public class SettlementRepository : ISettlementRepository
    {
        public void CreateSettlement(Settlements Settlement)
        {
            throw new NotImplementedException();
        }

        public Task DeleteSettlement(SettlementsAC Settlement)
        {
            throw new NotImplementedException();
        }

        public Task<SettlementsAC> GetSettlement(int id)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<SettlementsAC> GetSettlements()
        {
            throw new NotImplementedException();
        }

        public IEnumerable<SettlementsAC> GetSettlementsByGroupId(int id)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<SettlementsAC> GetSettlementsByUserId(string id)
        {
            throw new NotImplementedException();
        }

        public Task Save()
        {
            throw new NotImplementedException();
        }

        public bool SettlementExists(int id)
        {
            throw new NotImplementedException();
        }

        public void UpdateSettlement(Settlements Settlement)
        {
            throw new NotImplementedException();
        }
    }
}
