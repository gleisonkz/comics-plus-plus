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
        }
        public ComicStoreIdentityDbContext(DbContextOptions<ComicStoreIdentityDbContext> options) : base(options) { }

    }
}
