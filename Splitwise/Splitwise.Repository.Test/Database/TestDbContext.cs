using Microsoft.EntityFrameworkCore;
using Splitwise.DomainModel;
using System;
using System.Collections.Generic;
using System.Text;

namespace Splitwise.Repository.Test.Database
{
    public class TestDbContext
    {
        public static SplitwiseDbContext Create(string databaseName)
        {
            var options = new DbContextOptionsBuilder<SplitwiseDbContext>()
                .UseInMemoryDatabase(nameof(databaseName))
                .Options;
            return new SplitwiseDbContext(options);
        }
    }
}
