using Splitwise.DomainModel.ApplicationClasses;
using Splitwise.DomainModel.Models;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Splitwise.Repository.PayerRepository
{
    public class PayerRepository : IPayerRepository
    {
        public void CreatePayer(Payers Payer)
        {
            throw new NotImplementedException();
        }

        public Task DeletePayer(PayersAC Payer)
        {
            throw new NotImplementedException();
        }

        public Task<PayersAC> GetPayer(int id)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<PayersAC> GetPayers()
        {
            throw new NotImplementedException();
        }

        public IEnumerable<PayersAC> GetPayersByExpenseId(int id)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<PayersAC> GetPayersByPayerId(string id)
        {
            throw new NotImplementedException();
        }

        public bool PayerExists(int id)
        {
            throw new NotImplementedException();
        }

        public void UpdatePayer(Payers Payer)
        {
            throw new NotImplementedException();
        }
    }
}
