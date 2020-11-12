using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace Splitwise.DomainModel.Models
{
    public class Expenses
    {
        #region Properties
        public int Id { get; set; }

        public int? GroupId { get; set; }
        [ForeignKey("GroupId")]
        public Groups Group { get; set; }

        public string PayerId { get; set; }
        [ForeignKey("PayerId")]
        public Users User { get; set; }
        public string Description { get; set; }
        public DateTime DateTime { get; set; }
        public string Currency { get; set; }
        public int Total { get; set; }
        public string SplitBy { get; set; }
        #endregion

    }
}
