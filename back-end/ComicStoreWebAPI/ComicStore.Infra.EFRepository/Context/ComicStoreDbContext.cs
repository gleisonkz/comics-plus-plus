using ComicStore.Domain.POCO;
using Microsoft.EntityFrameworkCore;

namespace ComicStore.Infra.EFRepository.Context
{
    public class ComicStoreDbContext : DbContext
    {
        //protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        //{
        //    optionsBuilder.UseSqlServer(@"Data Source=.\sqlexpress;Initial Catalog=ComicStore;Integrated Security=True");
        //}
        //protected override void OnModelCreating(ModelBuilder modelBuilder)
        //{
        //    base.OnModelCreating(modelBuilder);

        //    modelBuilder.Entity<Comic>().HasMany(c => c.Author);
        //    modelBuilder.Entity<Author>().HasMany(c => c.Comic);
        //    modelBuilder.Entity<ComicAuthor>()
        //                .HasKey(c => new { c.AuthorID,c.ComicID });
        //}

        public ComicStoreDbContext(DbContextOptions<ComicStoreDbContext> options) : base(options) { }
        public DbSet<Comic> Comic { get; set; }
        public DbSet<Author> Author { get; set; }
        public DbSet<Genre> Genre { get; set; }
    }
}
