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

    public class NewFriendAC
    {
        public string UserId { get; set; }
        public string UserFriendEmail { get; set; }
    }
    public class RemoveFriendAC
    {
        public string UserId { get; set; }
        public string UserFriendId { get; set; }
    }
}
