using Splitwise.DomainModel.ApplicationClasses;
using Splitwise.DomainModel.Models;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Splitwise.Repository.PayerRepository
{
    public interface IPayerRepository
    {
        IEnumerable<PayersAC> GetPayers();
        IEnumerable<PayersAC> GetPayersByExpenseId(int id);
        IEnumerable<PayersAC> GetPayersByPayerId(string id);
        Task<IEnumerable<PayersAC>> GetExpensesByPayerId(string payerId);
        Task<PayersAC> GetPayer(int id);
        void CreatePayer(Payers Payer);
        Task UpdatePayer(string payerId, int expenseId, Payers payer);
        Task DeletePayer(PayersAC Payer);
        bool PayerExists(int id);
        Task Save();
    }
}
