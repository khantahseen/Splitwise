using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace Splitwise.DomainModel.Models
{
    public class Payers
    {
        #region Properties
        public int Id { get; set; }
        public int ExpenseId { get; set; }
        [ForeignKey("ExpenseId")]
        public Expenses Expense { get; set; }
        public string PayerId { get; set; }
        [ForeignKey("PayerId")]
        public Users User { get; set; }
        public int AmountPaid { get; set; }
        public int PayerShare { get; set; }
        public int PayerInitialShare { get; set; }
        #endregion
    }
}
