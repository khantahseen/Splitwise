using System;
using System.Collections.Generic;
using System.Text;

namespace Splitwise.DomainModel.ApplicationClasses
{
    public class UserFriendAC
    {
        #region Properties
        public int Id { get; set; }
        public string UserId { get; set; }
        public UsersAC User { get; set; }
        public string FriendId { get; set; }
        public UsersAC Friend { get; set; }
        #endregion

    }

    public class NewFriendAC
    {
        #region Properties
        public string UserId { get; set; }
        public string UserFriendEmail { get; set; }
        #endregion
    }
    public class RemoveFriendAC
    {
        #region Properties
        public string UserId { get; set; }
        public string UserFriendId { get; set; }
        #endregion
    }
}
