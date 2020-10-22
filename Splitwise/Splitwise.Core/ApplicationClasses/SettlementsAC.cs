using System;
using System.Collections.Generic;
using System.Text;

namespace Splitwise.Core.ApplicationClasses
{
    public class SettlementsAC
    {
        public int Id { get; set; }
        public int? GroupId { get; set; }
        public GroupsAC Group { get; set; }
        public string PayerId { get; set; }
        public UsersAC Payer { get; set; }
        public string PayeeId { get; set; }
        public UsersAC Payee { get; set; }
        public DateTime DateTime { get; set; }
        public int Amount { get; set; }
    }
}
