using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Internal;
using RELS.Model;
using Property = RELS.Model.Property;

namespace RELS.Context
{
    public class RealEstateDbContext : DbContext
    {
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
        public DbSet<Owner> Owners { get;  set; }
        public DbSet<FavoriteHistory> FavoriteHistories { get; set; }
        public DbSet<OwnerHistory> OwnerHistories { get; set; }
        public DbSet<DocumentHistory> DocumentHistories { get; set; }
        public DbSet<LessorHistory> LessorHistories { get; set; }
        public DbSet<PermissionHistory> PermissionHistories { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            modelBuilder.Entity<User>()
                .HasKey(u => u.Id);

            base.OnModelCreating(modelBuilder);
            modelBuilder.Entity<PermissionXUser>()
                       .HasNoKey();

            base.OnModelCreating(modelBuilder);
            modelBuilder.Entity<Permission>()
                        .HasKey(u => u.Id);

            base.OnModelCreating(modelBuilder);
            modelBuilder.Entity<Person>()
                        .HasKey(u => u.Id);

            base.OnModelCreating(modelBuilder);
            modelBuilder.Entity<TypeDocument>()
                        .HasKey(u => u.Id);

            base.OnModelCreating(modelBuilder);
            modelBuilder.Entity<Lessor>()
                        .HasKey(u => u.Id);

            base.OnModelCreating(modelBuilder);
            modelBuilder.Entity<PropertyXOwner>()
                        .HasNoKey();

            base.OnModelCreating(modelBuilder);
            modelBuilder.Entity<PropertyXLessor>()
                        .HasNoKey();

            base.OnModelCreating(modelBuilder);
            modelBuilder.Entity<Property>()
                        .HasKey(u => u.Id);

            base.OnModelCreating(modelBuilder);
            modelBuilder.Entity<Document>()
                        .HasKey(u => u.Id);

            base.OnModelCreating(modelBuilder);
            modelBuilder.Entity<Owner>()
                        .HasKey(u => u.Id);

            base.OnModelCreating(modelBuilder);
            modelBuilder.Entity<Favorite>()
                        .HasKey(u => u.Id);

            base.OnModelCreating(modelBuilder);
            modelBuilder.Entity<State>()
                        .HasKey(u => u.Id);

            base.OnModelCreating(modelBuilder);
            modelBuilder.Entity<TypeProperty>()
                        .HasKey(u => u.Id);

            base.OnModelCreating(modelBuilder);
            modelBuilder.Entity<Sector>()
                        .HasKey(u => u.Id);

            base.OnModelCreating(modelBuilder);
            modelBuilder.Entity<Person>()
                        .HasKey(u => u.Id);

            base.OnModelCreating(modelBuilder);
            modelBuilder.Entity<DocumentHistory>()
                        .HasKey(u => u.Id);

            base.OnModelCreating(modelBuilder);
            modelBuilder.Entity<FavoriteHistory>()
                        .HasKey(u => u.Id);

            base.OnModelCreating(modelBuilder);
            modelBuilder.Entity<LessorHistory>()
                        .HasKey(u => u.Id);

            base.OnModelCreating(modelBuilder);
            modelBuilder.Entity<OwnerHistory>()
                        .HasKey(u => u.Id);

            base.OnModelCreating(modelBuilder);
            modelBuilder.Entity<PermissionHistory>()
                        .HasKey(u => u.Id);


            //Builder Triggers
            modelBuilder.Entity<Document>().ToTable(tb => tb.UseSqlOutputClause(false));
            modelBuilder.Entity<Favorite>().ToTable(tb => tb.UseSqlOutputClause(false));
            modelBuilder.Entity<Owner>().ToTable(tb => tb.UseSqlOutputClause(false));
            modelBuilder.Entity<Permission>().ToTable(tb => tb.UseSqlOutputClause(false));
            modelBuilder.Entity<Lessor>().ToTable(tb => tb.UseSqlOutputClause(false));
        }
    }

}
