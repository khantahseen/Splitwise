using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace Splitwise.DomainModel.Models
{
    public class Settlements
    {
        #region Properties
        public int Id { get; set; }

        public int? GroupId { get; set; }
        [ForeignKey("GroupId")]
        public Groups Group { get; set; }

        public string PayerId { get; set; }
        [ForeignKey("PayerId")]
        public Users Payer { get; set; }

        public string PayeeId { get; set; }
        [ForeignKey("PayeeId")]
        public Users Payee { get; set; }
        public DateTime DateTime { get; set; }
        public int ExpenseId { get; set; }
        [ForeignKey("ExpenseId")]
        public Expenses SettleExpense { get; set; }
        public int Amount { get; set; }
        #endregion
    }
}
