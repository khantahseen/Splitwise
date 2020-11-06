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
        Task<IEnumerable<UsersAC>> GetAllFriends(string userId);
        Task<UsersAC> CreateUserFriendByEmail(string userId, string userFriendEmail);
        Task<UserFriendAC> DeleteUserFriendById(string userId, string friendId);
        bool FriendExistsByEmail(string userId, string userFriendEmail);
        bool FriendExistsById(string userId, string friendId);
    }
}
