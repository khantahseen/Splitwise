using System;
using System.Collections.Generic;
using System.Text;

namespace Splitwise.DomainModel.ApplicationClasses
{
    public class PayeesAC
    {
        #region Properties
        public int Id { get; set; }
        public int ExpenseId { get; set; }
        public ExpensesAC Expense { get; set; }
        public string PayeeId { get; set; }
        public UsersAC User { get; set; }
        public int PayeeShare { get; set; }
        public int PayeeInitialShare { get; set; }
        #endregion
    }
}
