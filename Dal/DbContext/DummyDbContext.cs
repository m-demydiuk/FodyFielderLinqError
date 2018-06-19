using Dal.Model;
using Microsoft.EntityFrameworkCore;

namespace Dal
{
    public class DummyDbContext : DbContext
    {
        public DummyDbContext(DbContextOptions<DummyDbContext> options) : base(options) { }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            var userBuilder = builder.Entity<User>();

            userBuilder.ToTable("User");
            userBuilder.HasKey(x => x.Id);
        }

        public DbSet<User> Users { get; set; }
    }
}