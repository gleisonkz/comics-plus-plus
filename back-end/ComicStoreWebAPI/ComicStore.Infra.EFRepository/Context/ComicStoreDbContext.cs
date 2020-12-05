using ComicStore.Domain.POCO;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using System.Reflection;

namespace ComicStore.Infra.EFRepository.Context
{
    public class ComicStoreDbContext : IdentityDbContext
    {
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder.ApplyConfigurationsFromAssembly(Assembly.GetExecutingAssembly()));
        }
        public ComicStoreDbContext(DbContextOptions<ComicStoreDbContext> options) : base(options) { }
        public DbSet<Comic> Comic { get; set; }
        public DbSet<Author> Author { get; set; }
        public DbSet<Genre> Genre { get; set; }
        public DbSet<ComicImage> ComicImage { get; set; }
    }
}
