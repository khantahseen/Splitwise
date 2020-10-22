using System;
using System.Collections.Generic;
using System.Text;

namespace Splitwise.DomainModel.ApplicationClasses
{
    public class ExpensesAC
    {
        public int Id { get; set; }

        public int? GroupId { get; set; }
        public GroupsAC Group { get; set; }
        public string PayerId { get; set; }
        public UsersAC User { get; set; }
        public string Description { get; set; }
        public DateTime DateTime { get; set; }
        public string Currency { get; set; }
        public int Total { get; set; }
        public string SplitBy { get; set; }
        
    }
}
