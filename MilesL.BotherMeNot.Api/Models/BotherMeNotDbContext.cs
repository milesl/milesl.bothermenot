using Microsoft.EntityFrameworkCore;

namespace MilesL.BotherMeNot.Api.Models
{
    /// <summary>
    /// The database context for Bother Me Not database
    /// </summary>
    /// <seealso cref="Microsoft.EntityFrameworkCore.DbContext" />
    public class BotherMeNotDbContext : DbContext
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="BotherMeNotDbContext"/> class.
        /// </summary>
        /// <param name="options">Database context options</param>
        public BotherMeNotDbContext(DbContextOptions<BotherMeNotDbContext> options)
            : base(options)
        {
        }

        /// <summary>
        /// Gets or sets the contacts.
        /// </summary>
        /// <value>
        /// The contacts.
        /// </value>
        public DbSet<Contact> Contacts { get; set; }

        /// <summary>
        /// Gets or sets the contact attempts.
        /// </summary>
        /// <value>
        /// The contact attempts.
        /// </value>
        public DbSet<ContactAttempt> ContactAttempts { get; set; }

        /// <summary>
        /// Overriden OnModelCreating method to ensure table mappings follow convention
        /// </summary>
        /// <param name="modelBuilder">The builder being used to construct the model for this context. Databases (and other extensions) typically
        /// define extension methods on this object that allow you to configure aspects of the model that are specific
        /// to a given database.</param>
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Contact>().ToTable("Contact");
            modelBuilder.Entity<ContactAttempt>().ToTable("ContactAttempt");
        }
    }
}
