using AutoMapper;
using Microsoft.AspNetCore.Identity;
using Splitwise.DomainModel;
using Splitwise.DomainModel.ApplicationClasses;
using Splitwise.DomainModel.Models;
using Splitwise.Repository.UserRepository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Splitwise.Repository.UserFriendRepository
{
    public class UserFriendRepository : IUserFriendRepository
    {
        private SplitwiseDbContext _context;
        private readonly IUsersRepository _usersRepository;
        private readonly IMapper _mapper;

        public UserFriendRepository(SplitwiseDbContext _context, IUsersRepository _usersRepository, IMapper _mapper)
        {
            this._context = _context;
            this._usersRepository = _usersRepository;
            this._mapper = _mapper;
            
        }
        public async Task<UsersAC> CreateUserFriendByEmail(string id, Users user)
        {
            string email = user.Email;
            var x = await _usersRepository.GetUserByEmail(email);
            if (x != null)
            {
                _context.UserFriend.Add(new UserFriend() { UserId = id, FriendId = x.Id });
                _context.UserFriend.Add(new UserFriend() { UserId = x.Id, FriendId = id });
                await _context.SaveChangesAsync();
                return x;
            }
            else
            {
                return _mapper.Map<UsersAC>(new Users());
            }
            //throw new NotImplementedException();
        }

        public async Task<UserFriendAC> GetUserFriend(int id)
        {
            return _mapper.Map<UserFriendAC>(await _context.FindAsync<UserFriend>(id));
            //throw new NotImplementedException();
        }

        public bool UserFriendExists(string id)
        {
            return _context.Users.Any(e => e.Id == id);
            //throw new NotImplementedException();
        }

        public Task DeleteUserFriend(UserFriendAC UserFriend)
        {
            throw new NotImplementedException();
        }

        public Task DeleteUserFriendById(string userid1, string userid2)
        {
            throw new NotImplementedException();
        }
    }
}
