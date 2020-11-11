using Splitwise.DomainModel.ApplicationClasses;
using Splitwise.DomainModel.Models;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Splitwise.Repository.PayeeRepository
{
    public interface IPayeeRepository
    {
        IEnumerable<PayeesAC> GetPayees();
        IEnumerable<PayeesAC> GetPayeesByExpenseId(int id);
        IEnumerable<PayeesAC> GetPayeesByPayeeId(string id);
        Task<IEnumerable<PayeesAC>> GetExpensesByPayeeId(string payeeId);
        void CreatePayee(Payees Payee);
        Task Save();
        bool PayeeExists(int id);
    }
}
