using Microsoft.EntityFrameworkCore;
using Comic.Business.POCO;

namespace Comic.RepositoryEF
{
    public class ComicContext : DbContext
    {
        public ComicContext(DbContextOptions<ComicContext> options) : base(options) { }

        public DbSet<Comic.Business.POCO.Comic> Comic { get; set; }
        public DbSet<Author> Author { get; set; }
        public DbSet<Genre> Genre { get; set; }
    }
}
