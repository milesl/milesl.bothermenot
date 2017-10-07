using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MilesL.BotherMeNot.Api.Models
{
    public class BotherMeNotDbContext : DbContext
    {
        public BotherMeNotDbContext(DbContextOptions<BotherMeNotDbContext> options) : base(options)
        {
        }

        public DbSet<Contact> Contacts { get; set; }

        public DbSet<ContactAttempt> ContactAttempts { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Contact>().ToTable("Contact");
            modelBuilder.Entity<ContactAttempt>().ToTable("ContactAttempt");
        }
    }
}
