using System;
using System.Collections.Generic;
using System.Text;

namespace Splitwise.DomainModel.ApplicationClasses
{
    public class UserFriendAC
    {
        public int Id { get; set; }
        public string UserId { get; set; }
        public UsersAC User { get; set; }
        public string FriendId { get; set; }
        public UsersAC Friend { get; set; }

    }
}
