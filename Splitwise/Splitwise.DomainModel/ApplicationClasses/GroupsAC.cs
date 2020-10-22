using System;
using System.Collections.Generic;
using System.Text;

namespace Splitwise.DomainModel.ApplicationClasses
{
    public class GroupsAC
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string AdminId { get; set; }
        public UsersAC User { get; set; }
    }
}
