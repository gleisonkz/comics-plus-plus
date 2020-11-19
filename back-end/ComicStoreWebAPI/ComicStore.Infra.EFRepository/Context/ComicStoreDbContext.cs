using ComicStore.Domain.POCO;
using Microsoft.EntityFrameworkCore;

namespace ComicStore.Infra.EFRepository.Context
{
    public class ComicStoreDbContext : DbContext
    {
        public ComicStoreDbContext(DbContextOptions<ComicStoreDbContext> options) : base(options) { }
        public DbSet<Comic> Comic { get; set; }
        public DbSet<Author> Author { get; set; }
        public DbSet<Genre> Genre { get; set; }
    }
}
