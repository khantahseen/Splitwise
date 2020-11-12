using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace Splitwise.DomainModel.Models
{
    public class Payees
    {
        #region Properties
        public int Id { get; set; }

        public int ExpenseId { get; set; }
        [ForeignKey("ExpenseId")]
        public Expenses Expense { get; set; }

        public string PayeeId { get; set; }
        [ForeignKey("PayeeId")]
        public Users User { get; set; }

        public int PayeeShare { get; set; }
        public int PayeeInitialShare { get; set; }
        #endregion
    }
}
