using Microsoft.EntityFrameworkCore;
using RELS.Model;

namespace RELS.Context
{
    public class RealEstateDbContext : DbContext
    {
        public RealEstateDbContext(DbContextOptions options) : base(options)
        {

        }
        public DbSet<User> Users { get; set; }
        public DbSet<UserType> UserTypes { get; set; }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            modelBuilder.Entity<User>()
                .HasKey(u=> u.Id);

          

        }
    }
    
}
