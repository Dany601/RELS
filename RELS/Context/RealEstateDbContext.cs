using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Internal;
using RELS.Model;
using Property = RELS.Model.Property;

namespace RELS.Context
{
    public class RealEstateDbContext : DbContext
    {
        internal object Owner;

        public RealEstateDbContext(DbContextOptions options) : base(options)
        {

        }
        public DbSet<User> Users { get; set; }
        public DbSet<UserType> UserTypes { get; set; }

        public DbSet<PermissionXUser> PermissionsXUser { get; set; }
        public DbSet<Permission> Permissions { get; set; }
        public DbSet<Person> People { get; set; }
        public DbSet<TypeDocument> TypesDocuments { get; set; }
        public DbSet<Lessor> Lessors { get; set; }
        public DbSet<PropertyXOwner> PropertiesXOwners { get; set; }
        public DbSet<PropertyXLessor> PropertiesXLessors { get; set; }
        public DbSet<Property> Properties { get; set; }
        public DbSet<Document> Documents { get; set; }
        public DbSet<Favorite> Favorites { get; set; }
        public DbSet<State> States { get; set; }
        public DbSet<TypeProperty> TypesProperties { get; set; }
        public DbSet<Sector> Sectors { get; set; }
        public object Owners { get; internal set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            modelBuilder.Entity<User>()
                .HasKey(u => u.UserId);

            base.OnModelCreating(modelBuilder);
            modelBuilder.Entity<PermissionXUser>()
                       .HasNoKey();

            base.OnModelCreating(modelBuilder);
            modelBuilder.Entity<Permission>()
                        .HasKey(u => u.PermissionId);

            base.OnModelCreating(modelBuilder);
            modelBuilder.Entity<Person>()
                        .HasKey(u => u.PersonId);

            base.OnModelCreating(modelBuilder);
            modelBuilder.Entity<TypeDocument>()
                        .HasKey(u => u.DocumentTypeId);

            base.OnModelCreating(modelBuilder);
            modelBuilder.Entity<Lessor>()
                        .HasKey(u => u.LessorId);

            base.OnModelCreating(modelBuilder);
            modelBuilder.Entity<PropertyXOwner>()
                        .HasNoKey();

            base.OnModelCreating(modelBuilder);
            modelBuilder.Entity<PropertyXLessor>()
                        .HasNoKey();

            base.OnModelCreating(modelBuilder);
            modelBuilder.Entity<Property>()
                        .HasKey(u => u.PropertyId);

            base.OnModelCreating(modelBuilder);
            modelBuilder.Entity<Document>()
                        .HasKey(u => u.Id);


            base.OnModelCreating(modelBuilder);
            modelBuilder.Entity<Favorite>()
                        .HasKey(u => u.FavoriteId);

            base.OnModelCreating(modelBuilder);
            modelBuilder.Entity<State>()
                        .HasKey(u => u.StateId);

            base.OnModelCreating(modelBuilder);
            modelBuilder.Entity<TypeProperty>()
                        .HasKey(u => u.TypePropertyId);

            base.OnModelCreating(modelBuilder);
            modelBuilder.Entity<Sector>()
                        .HasKey(u => u.SectorIdId);

            base.OnModelCreating(modelBuilder);
            modelBuilder.Entity<Person>()
                        .HasOne(p => p.Owner)
                        .WithOne(p => p.Person)
                        .HasForeignKey<Owner>(o => o.PersonId);

            base.OnModelCreating(modelBuilder);
            modelBuilder.Entity<Person>()
                        .HasOne(p => p.Lessor)
                        .WithOne(p => p.Person)
                        .HasForeignKey<Lessor>(o => o.PersonId);

            base.OnModelCreating(modelBuilder);
            modelBuilder.Entity<Person>()
                        .HasOne(p => p.User)
                        .WithOne(p => p.Person)
                        .HasForeignKey<User>(o => o.PersonId);
        }
    }

}
