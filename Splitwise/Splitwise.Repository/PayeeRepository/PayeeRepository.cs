using Splitwise.DomainModel.ApplicationClasses;
using Splitwise.DomainModel.Models;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Splitwise.Repository.PayeeRepository
{
    public class PayeeRepository : IPayeeRepository
    {
        public void CreatePayee(Payees Payee)
        {
            throw new NotImplementedException();
        }

        public Task DeletePayee(PayeesAC Payee)
        {
            throw new NotImplementedException();
        }

        public Task<PayeesAC> GetPayee(int id)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<PayeesAC> GetPayees()
        {
            throw new NotImplementedException();
        }

        public IEnumerable<PayeesAC> GetPayeesByExpenseId(int id)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<PayeesAC> GetPayeesByPayeeId(string id)
        {
            throw new NotImplementedException();
        }

        public bool PayeeExists(int id)
        {
            throw new NotImplementedException();
        }

        public Task Save()
        {
            throw new NotImplementedException();
        }

        public void UpdatePayee(Payees Payee)
        {
            throw new NotImplementedException();
        }
    }
}
