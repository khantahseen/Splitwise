using NUnit.Framework;
using Splitwise.DomainModel.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Splitwise.Repository.Test.Database
{
    public class DatabaseTest
    {
        [SetUp]
        public void SetUp()
        {
        }

        [TestCase("test", "testgmailcom")]
        public void TestDatabase(string name,string username)
        {
            Users sampleuser = new Users { Name = name, UserName= username};
            using (var db = TestDbContext.Create(nameof(TestDatabase)))
            {
                db.Users.Add(sampleuser);
                db.SaveChanges();
            }
            using (var db = TestDbContext.Create(nameof(TestDatabase)))
            {
                var savedUser = db.Users.Single();
                Assert.AreEqual(sampleuser.Name, savedUser.Name);
                Assert.AreEqual(sampleuser.UserName, savedUser.UserName);
            }

        }
    }
}
