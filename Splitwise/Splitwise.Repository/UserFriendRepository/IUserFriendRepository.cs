using Microsoft.AspNetCore.Identity;
using Splitwise.DomainModel.ApplicationClasses;
using Splitwise.DomainModel.Models;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Splitwise.Repository.UserFriendRepository
{
    public interface IUserFriendRepository
    {
        Task<UserFriendAC> GetUserFriend(int id);

        //void CreateUserFriend(UserFriend UserFriend);
        Task<UsersAC> CreateUserFriendByEmail(string id, Users user);
        Task DeleteUserFriend(UserFriendAC UserFriend);
        Task DeleteUserFriendById(string userid1, string userid2);
        bool UserFriendExists(string id);
    }
}
