using Splitwise.DomainModel.ApplicationClasses;
using Splitwise.DomainModel.Models;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Splitwise.Repository.UserFriendRepository
{
    public class UserFriendRepository : IUserFriendRepository
    {
        public void CreateUserFriend(UserFriend UserFriend)
        {
            throw new NotImplementedException();
        }

        public Task<UsersAC> CreateUserFriendByEmail(string id, Users user)
        {
            throw new NotImplementedException();
        }

        public Task DeleteUserFriend(UserFriendAC UserFriend)
        {
            throw new NotImplementedException();
        }

        public Task DeleteUserFriendById(string userid1, string userid2)
        {
            throw new NotImplementedException();
        }

        public Task<UserFriendAC> GetUserFriend(int id)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<UserFriendAC> GetUserFriends()
        {
            throw new NotImplementedException();
        }

        public void UpdateUserFriend(UserFriend UserFriend)
        {
            throw new NotImplementedException();
        }

        public bool UserFriendExists(string id)
        {
            throw new NotImplementedException();
        }
    }
}
