using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using Splitwise.DomainModel.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace Splitwise.DomainModel
{
    public class SplitwiseDbContext:IdentityDbContext<Users>
    {
        public SplitwiseDbContext(DbContextOptions<SplitwiseDbContext> options) : base(options)
        {

        }
        public DbSet<Groups> Groups { get; set; }
        public DbSet<GroupMember> GroupMember { get; set; }
        public DbSet<UserFriend> UserFriend { get; set; }
        public DbSet<Expenses> Expenses { get; set; }
        public DbSet<Payers> Payers { get; set; }
        public DbSet<Payees> Payees { get; set; }
        public DbSet<Settlements> Settlements { get; set; }
    }
}
