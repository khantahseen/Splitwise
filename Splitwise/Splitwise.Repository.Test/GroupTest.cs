using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Text;
using Splitwise.Repository.GroupRepository;
using Splitwise.DomainModel.Models;

namespace Splitwise.Repository.Test
{
    [TestClass]
    public class UnitTest2
    {
        GroupsRepository user = new GroupsRepository();
        [TestMethod]
        public void CreateUserTest()
        {
            Groups u1 = new Groups();
            Assert.ThrowsExceptionAsync<NotImplementedException>(() => user.CreateGroup(u1));
        }
    }
}
