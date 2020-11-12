using Microsoft.AspNetCore.Mvc;
using Splitwise.DomainModel.ApplicationClasses;
using Splitwise.Repository.UserFriendRepository;
using Splitwise.Repository.UserRepository;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Splitwise.Core.ApiControllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserFriendController:ControllerBase
    {
        private readonly IUserFriendRepository _userFriendRepository;
        private readonly IUsersRepository _usersRepository;

        public UserFriendController(IUserFriendRepository _userFriendRepository, IUsersRepository _usersRepository)
        {
            this._userFriendRepository = _userFriendRepository;
            this._usersRepository = _usersRepository;
        }


        // GET: api/UserFriends/5
        [HttpGet("{userId}")]
        public async Task<ActionResult<IEnumerable<UsersAC>>> GetAllFriends([FromRoute] string userId)
        {
            return Ok(await _userFriendRepository.GetAllFriends(userId));
        }

        [HttpPost]
        public async Task<ActionResult<UsersAC>> AddFriend(NewFriendAC friend)
        {
            if (ModelState.IsValid)
            {
                if (this._usersRepository.UserExistsByEmail(friend.UserFriendEmail))
                {
                    if (this.FriendExistsByEmail(friend.UserId, friend.UserFriendEmail) == false)
                    {
                        var userFriend = await this._userFriendRepository.CreateUserFriendByEmail(friend.UserId, friend.UserFriendEmail);
                        return Ok(userFriend);
                    }
                    return BadRequest(new { message = "Already a friend" });
                }
                return NotFound(new { message = "Friend User is not registered" });
            }
            return BadRequest();
        }
        [HttpDelete]
        public async Task<ActionResult<UsersAC>> RemoveFriend(RemoveFriendAC friend)
        {
            if (ModelState.IsValid)
            {
                if (this._usersRepository.UserExists(friend.UserFriendId))
                {
                    if (this.FriendExistsById(friend.UserId, friend.UserFriendId))
                    {
                        var removedFriend = await this._userFriendRepository.DeleteUserFriendById(friend.UserId, friend.UserFriendId);
                        return Ok(removedFriend);
                    }
                    return BadRequest(new { message = "Not a friend" });
                }
                return NotFound(new { message = "Friend User is not registered" });
            }
            return BadRequest();
        }
        private bool FriendExistsById(string userId, string userFriendId)
        {
            return _userFriendRepository.FriendExistsById(userId, userFriendId);
        }
        private bool FriendExistsByEmail(string userId, string userFriendEmail)
        {
            return _userFriendRepository.FriendExistsByEmail(userId, userFriendEmail);
        }
    }
}
