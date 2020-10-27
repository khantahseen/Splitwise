using Microsoft.AspNetCore.Identity;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Splitwise.DomainModel.Models;
using Splitwise.Repository.UserRepository;
using System;
using System.Threading.Tasks;

namespace Splitwise.Repository.Test
{
    [TestClass]
    public class UnitTest1
    {
        UsersRepository user = new UsersRepository();
        [TestMethod]
        public void CreateUserTest()
        {
            Users u1 = new Users();
            Assert.ThrowsExceptionAsync<NotImplementedException>(() => user.CreateUser(u1));
        }

        [TestMethod]
        public void GetUsersTest()
        {
            Assert.ThrowsExceptionAsync<NotImplementedException>(() => (Task)user.GetUsers());
        }

        [TestMethod]
        public void GetAllFriendsTest()
        {
            Assert.ThrowsExceptionAsync<NotImplementedException>(() => (Task)user.GetAllFriends("a"));
        }
    }
}
