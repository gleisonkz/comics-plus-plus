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

            modelBuilder.Entity<IdentityUser>().HasData(
                new IdentityUser
                {
                    Id = "8ceb39d0-530b-4016-955e-fb4e713714eb",
                    UserName = "admin@comicstore.com",
                    Email = "admin@comicstore.com",
                    EmailConfirmed = true,
                    PasswordHash = "AQAAAAEAACcQAAAAEPjNHxphxpBQUr5OiMGjilGAhA4laW0HUkbUK42CvlC9JEu1HvTZ6v6EL/n9ktnzFg==",
                    SecurityStamp = "AHZGG2P4K6A7LOXC4YPTW2QAZKU52XON",
                    ConcurrencyStamp = "72df09dd-9a6c-4655-a700-6885eb58e37d"
                });

        }
        public ComicStoreIdentityDbContext(DbContextOptions<ComicStoreIdentityDbContext> options) : base(options) { }

    }
}
