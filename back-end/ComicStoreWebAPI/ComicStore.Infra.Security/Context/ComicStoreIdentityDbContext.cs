using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace ComicStore.Infra.EFRepository.Context
{
    public class ComicStoreIdentityDbContext : IdentityDbContext
    {
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            modelBuilder.HasDefaultSchema("seg");

            foreach (var entityType in modelBuilder.Model.GetEntityTypes())
            {
                var tableName = entityType.GetTableName();
                if (tableName.StartsWith("AspNet"))
                {
                    entityType.SetTableName(tableName.Substring(6));
                }
            }

            var hasher = new PasswordHasher<IdentityUser>();
            

            modelBuilder.Entity<IdentityUser>().HasData(
                        new IdentityUser
                        {
                            Id = "1",
                            UserName = "admin@comicstore.com",
                            NormalizedUserName = "admin@comicstore.com".ToUpper(),
                            NormalizedEmail = "admin@comicstore.com".ToUpper(),
                            Email = "admin@comicstore.com",
                            EmailConfirmed = true,
                            PasswordHash = hasher.HashPassword(null, "@DMINc0m1cst0r34dm1n")
                        });

            modelBuilder.Entity<IdentityRole>().HasData(
                        new IdentityRole
                        {
                            Id = "1",
                            Name = "Admin",
                            NormalizedName = "Admin".ToUpper()

                        });

            modelBuilder.Entity<IdentityRole>().HasData(
                        new IdentityRole
                        {
                            Id = "2",
                            Name = "User",
                            NormalizedName = "User".ToUpper()
                        });


            modelBuilder.Entity<IdentityUserRole<string>>().HasData(
                        new IdentityUserRole<string>
                        {
                            RoleId = "1",
                            UserId = "1"
                        });

        }
        public ComicStoreIdentityDbContext(DbContextOptions<ComicStoreIdentityDbContext> options) : base(options) { }

    }
}
