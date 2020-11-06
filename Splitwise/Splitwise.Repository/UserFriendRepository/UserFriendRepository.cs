using AutoMapper;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
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

        public async Task<IEnumerable<UsersAC>> GetAllFriends(string userId)
        {
            var users = await this._context.UserFriend
                .Where(p => p.UserId == userId)
                .Include(p => p.Friend)
                .Select(p => p.Friend).ToListAsync();
            return this._mapper.Map<IEnumerable<UsersAC>>(users);
            // return this._mapper.Map<IEnumerable<UsersAC>>(_context.UserFriend.Include(f=>f.Friend).Where(u=>u.UserId==userId).ToList());
            //throw new NotImplementedException();
            // return _mapper.Map<IEnumerable<PayersAC>>
            //(_context.Payers.Include(t => t.User).Where(e => e.PayerId == id).ToList());
        }

        public async Task<UsersAC> CreateUserFriendByEmail(string userId, string userFriendEmail)
        {
            UserFriend friend = new UserFriend();
            friend.Id = 0;
            friend.UserId = userId;
            var user = await _usersRepository.GetUserByEmail(userFriendEmail);
            friend.FriendId = user.Id;
            _context.UserFriend.Add(friend);
            await _context.SaveChangesAsync();
            return _mapper.Map<UsersAC>(user);
            //throw new NotImplementedException();
        }

        public async Task<UserFriendAC> DeleteUserFriendById(string userId, string friendId)
        {
            try
            {
                var friendToRemove = this._context.UserFriend.Where(e => (e.UserId == userId) && (e.FriendId == friendId)).FirstOrDefault();
                this._context.Remove(friendToRemove);
                await _context.SaveChangesAsync();
                return this._mapper.Map<UserFriendAC>(friendToRemove);
            }
            catch (Exception e)
            {
                return null;
            }
            //throw new NotImplementedException();
        }

        public bool FriendExistsByEmail(string userId, string userFriendEmail)
        {
            return _context.UserFriend.Any(e => (e.UserId == userId) && (e.Friend.Email == userFriendEmail));
            //throw new NotImplementedException();
        }

        public bool FriendExistsById(string userId, string friendId)
        {
            return _context.UserFriend.Any(e => (e.UserId == userId) && (e.FriendId == friendId));
            //throw new NotImplementedException();
        }
    }
}