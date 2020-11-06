using Splitwise.DomainModel.ApplicationClasses;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Splitwise.DomainModel.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.Configuration;
using System.Security.Claims;
using System.IdentityModel.Tokens.Jwt;
using Microsoft.IdentityModel.Tokens;
using AutoMapper;
using System.Linq;
using Microsoft.EntityFrameworkCore;
using Splitwise.DomainModel;

namespace Splitwise.Repository.UserRepository
{
    public class UsersRepository : IUsersRepository
    {
        private readonly UserManager<Users> _userManager;
        private readonly IConfiguration _configuration;
        private readonly IMapper _mapper;
        private readonly SplitwiseDbContext _context;


        public UsersRepository(SplitwiseDbContext _context,UserManager<Users> _userManager, IConfiguration _configuration, IMapper _mapper)
        {
            this._context = _context;
            this._userManager = _userManager;
            this._configuration = _configuration;
            this._mapper = _mapper;
        }

        public async Task<IdentityResult> Register(Register register)
        {
            var user = new Users
            {
                Name = register.Name,
                Email = register.Email,
                UserName = register.Email,
            };
            var checkUser = await _userManager.FindByEmailAsync(register.Email);
            if (checkUser == null)
            {
                return await _userManager.CreateAsync(user, register.Password);
            }
            return null;
        }

        public async Task<string> Login(LoginAC login)
        {
            var user = await _userManager.FindByNameAsync(login.Email);
            if (user != null && await _userManager.CheckPasswordAsync(user, login.Password))
            {
                var userRoles = await _userManager.GetRolesAsync(user);

                var authClaims = new List<Claim>
                {
                    new Claim("name", user.UserName),
                    new Claim(ClaimTypes.Name, user.UserName),
                    new Claim(JwtRegisteredClaimNames.Jti, Guid.NewGuid().ToString()),
                };

                foreach (var userRole in userRoles)
                {
                    authClaims.Add(new Claim("role", userRole));
                    authClaims.Add(new Claim(ClaimTypes.Role, userRole));
                }

                var authSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_configuration["JWT:Secret"]));

                var token = new JwtSecurityToken(
                    issuer: _configuration["JWT:ValidIssuer"],
                    audience: _configuration["JWT:ValidAudience"],
                    expires: DateTime.Now.AddHours(3),
                    claims: authClaims,
                    signingCredentials: new SigningCredentials(authSigningKey, SecurityAlgorithms.HmacSha256)
                    );

                var returntoken = new JwtSecurityTokenHandler().WriteToken(token);
                return returntoken;
            }
            return null;
            //throw new NotImplementedException();
        }

        public IEnumerable<UsersAC> GetUsers()
        {
            return _mapper.Map<IEnumerable<UsersAC>>(_userManager.Users);
            //throw new NotImplementedException();
        }
        public IEnumerable<UsersAC> GetAllFriends(string id)
        {
            throw new NotImplementedException();
        }

        public async Task<UsersAC> GetUser(string id)
        {
            return _mapper.Map<UsersAC>(await _userManager.Users.Where(u => u.Id == id).FirstAsync());
            //throw new NotImplementedException();
        }

        public async Task<UsersAC> GetUserByEmail(string email)
        {
            return _mapper.Map<UsersAC>(await _userManager.Users.Where(u =>u.Email == email).SingleOrDefaultAsync());
            //throw new NotImplementedException();
        }

        public async Task<IdentityResult> UpdateUser(UsersAC user)
        {
            Users u = await _userManager.FindByIdAsync(user.Id);
            u.Name = user.Name;
            u.Email = user.Email;
            u.UserName = user.UserName;

            return await _userManager.UpdateAsync(u);
            //_context.Entry(user).State = EntityState.Modified;
            //throw new NotImplementedException();
        }
        
        public async Task Save()
        {
             await _context.SaveChangesAsync();
            //throw new NotImplementedException();
        }

       
        public bool UserExists(string id)
        {
            return _context.Users.Any(u => u.Id == id);
            //throw new NotImplementedException();
        }

        public async Task DeleteUser(string id)
        {
            var user = await _userManager.Users.Where(u => u.Id == id).SingleOrDefaultAsync();
            if (user != null)
            {
                await _userManager.DeleteAsync(user);
            }
            //throw new NotImplementedException();
        }

        public bool UserExistsByEmail(string userEmail)
        {
            return this._userManager.Users.Any(e => e.Email == userEmail);
            //throw new NotImplementedException();
        }
    }
}
