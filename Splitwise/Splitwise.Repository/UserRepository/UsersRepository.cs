using Splitwise.DomainModel.ApplicationClasses;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Splitwise.DomainModel.Models;
using Microsoft.AspNetCore.Identity;

namespace Splitwise.Repository.UserRepository
{
    public class UsersRepository : IUsersRepository
    {
        private readonly UserManager<Users> _userManager;

        public UsersRepository(UserManager<Users> _userManager)
        {
            this._userManager = _userManager;
        }
        public async Task CreateUser(Users user)
        {
           await _userManager.CreateAsync(user);
           //throw new NotImplementedException();
        }

        public Task DeleteUser(UsersAC user)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<UsersAC> GetAllFriends(string id)
        {
            throw new NotImplementedException();
        }

        public Task<UsersAC> GetUser(string id)
        {
            throw new NotImplementedException();
        }

        public Task<UsersAC> GetUserByEmail(string email)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<UsersAC> GetUsers()
        {
            throw new NotImplementedException();
        }

        public void UpdateUser(Users user)
        {
            throw new NotImplementedException();
        }

        public bool UserExists(string id)
        {
            throw new NotImplementedException();
        }
    }
}
