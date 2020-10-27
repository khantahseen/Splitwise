using Microsoft.AspNetCore.Identity;
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
        Task<IdentityResult> Register(Register register);
        Task<string> Login(LoginAC login);
        IEnumerable<UsersAC> GetUsers();
        IEnumerable<UsersAC> GetAllFriends(string id);
        Task<UsersAC> GetUser(string id);
        Task<UsersAC> GetUserByEmail(string email);
        void UpdateUser(Users user);
        bool UserExists(string id);
        Task Save();
    }
}
