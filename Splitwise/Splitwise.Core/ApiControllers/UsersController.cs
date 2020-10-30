using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Splitwise.DomainModel;
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
        private readonly SplitwiseDbContext _context;

        public UsersController(IUsersRepository usersRepository, UserManager<Users> userManager, SplitwiseDbContext _context)
        {
            this._usersRepository = usersRepository;
            _userManager = userManager;
            this._context = _context;
        }

        [HttpPost]
        [Route("register")]
        public async Task<IActionResult> Register(Register register)
        {
            var RegisteReturnModel = await _usersRepository.Register(register);
            if (RegisteReturnModel != null)
            {
                return Ok(RegisteReturnModel);
            }
            else
            {
                return BadRequest(new { message = "User with Same Email Exist!!" });
            }
        }

        [HttpPost]
        [Route("login")]
        public async Task<IActionResult> Login([FromBody] LoginAC login)
        {
            var loginReturnModel = await _usersRepository.Login(login);
            if (loginReturnModel != null)
            {
                return Ok(loginReturnModel);
            }
            else
            {
                return BadRequest(new { message = "Username or Password is Incorrect." });
            }
        }

        // GET: api/Users
        [HttpGet]
        public IEnumerable<UsersAC> GetUsers()
        {
            return _usersRepository.GetUsers();
        }

        // GET: api/Users/5
        [HttpGet("{id}")]
        public async Task<IActionResult> GetUser([FromRoute] string id)
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

        // GET: api/Users/ByEmail/abc@gmail.com
        [HttpGet("ByEmail/{email}")]
        public async Task<IActionResult> GetUserByEmail([FromRoute] string email)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var users = await _usersRepository.GetUserByEmail(email);

            if (users == null)
            {
                return NotFound();
            }

            return Ok(users);
        }

        // PUT: api/Users/5
        [HttpPut("{id}")]
        public async Task<IActionResult> PutUsers([FromRoute] string id, [FromBody] UsersAC users)
        {
            var u1 = await _usersRepository.UpdateUser(users);
            if(u1!=null)
            {
                return Ok(u1);
            }
            return NotFound();
        }

        //DELETE: api/user/id
        [HttpDelete("{id}")]
        public async Task<ActionResult> DeleteEmployee(string id)
        {
            if (UsersExist(id))
            {
                await this._usersRepository.DeleteUser(id);
                return Ok();
            }
            return NotFound();
        }
        private bool UsersExist(string id)
        {
            return _usersRepository.UserExists(id);
        }

    }
}
