using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Splitwise.DomainModel.ApplicationClasses;
using Splitwise.DomainModel.Models;
using Splitwise.Repository.UserRepository;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Splitwise.Core.ApiControllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UsersController:ControllerBase
    {
        private readonly IUsersRepository _usersRepository;
        private readonly UserManager<Users> _userManager;

        public UsersController(IUsersRepository usersRepository, UserManager<Users> userManager)
        {
            this._usersRepository = usersRepository;
            _userManager = userManager;
        }

        // GET: api/Users
        [HttpGet]
        public IEnumerable<UsersAC> GetUsers()
        {
            return _usersRepository.GetUsers();
        }

        // GET: api/Users/5
        [HttpGet("{id}")]
        public async Task<IActionResult> GetUsers([FromRoute] string id)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var users = await _usersRepository.GetUser(id);

            if (users == null)
            {
                return NotFound();
            }

            return Ok(users);
        }

        // PUT: api/Users/5
        [HttpPut("{id}")]
        public async Task<IActionResult> PutUsers([FromRoute] string id, [FromBody] Users users)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != users.Id)
            {
                return BadRequest();
            }

            _usersRepository.UpdateUser(users);

            try
            {
                await _usersRepository.Save();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!UsersExists(id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return NoContent();
        }

        // DELETE: api/Users/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteUsers([FromRoute] string id)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var users = await _usersRepository.GetUser(id);
            if (users == null)
            {
                return NotFound();
            }
            await _usersRepository.DeleteUser(users);
            //await _usersRepository.Save();

            return Ok(users);
        }

        // POST: api/Users
        [HttpPost]
        public async Task<IActionResult> PostUsers([FromBody] Users users)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            await _usersRepository.CreateUser(users);
            //await _usersRepository.Save();

            return CreatedAtAction("GetUsers", new { id = users.Id }, users);
        }

        private bool UsersExists(string id)
        {
            return _usersRepository.UserExists(id);
        }

    }
}
