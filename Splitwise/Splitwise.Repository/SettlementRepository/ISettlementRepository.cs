using Splitwise.DomainModel.ApplicationClasses;
using Splitwise.DomainModel.Models;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Splitwise.Repository.SettlementRepository
{
    public interface ISettlementRepository
    {
        IEnumerable<SettlementsAC> GetSettlements();
        IEnumerable<SettlementsAC> GetSettlementsByUserId(string id);
        IEnumerable<SettlementsAC> GetSettlementsByGroupId(int id);
        Task<SettlementsAC> GetSettlement(int id);
        void CreateSettlement(Settlements Settlement);
        bool SettlementExists(int id);
        Task Save();
    }
}
