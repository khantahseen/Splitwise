using Splitwise.DomainModel.ApplicationClasses;
using Splitwise.DomainModel.Models;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Splitwise.Repository.UserRepository
{
    public interface IUsersRepository
    {
        IEnumerable<UsersAC> GetUsers();
        IEnumerable<UsersAC> GetAllFriends(string id);
        Task<UsersAC> GetUser(string id);
        Task<UsersAC> GetUserByEmail(string email);
        Task CreateUser(Users user);
        void UpdateUser(Users user);
        Task DeleteUser(UsersAC user);
        bool UserExists(string id);
    }
}
