using System;
using System.Collections.Generic;
using System.Text;

namespace Splitwise.Core.ApplicationClasses
{
    public class GroupMemberAC
    {
        public int Id { get; set; }
        public int GroupId { get; set; }
        public GroupsAC Group { get; set; }
        public string MemberId { get; set; }
        public UsersAC User { get; set; }
    }
}
