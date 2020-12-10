using ComicStore.Domain.POCO;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Reflection;

namespace ComicStore.Infra.EFRepository.Context
{
    public class ComicStoreDbContext : DbContext
    {
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {

            base.OnModelCreating(modelBuilder.ApplyConfigurationsFromAssembly(Assembly.GetExecutingAssembly()));

            var genres = new List<Genre>
            {
                new Genre { GenreID = 1, Description = "Ação" },
                new Genre { GenreID = 2, Description = "Aventura"},
                new Genre { GenreID = 3, Description = "Drama" },
                new Genre { GenreID = 4, Description = "Comedia" },
                new Genre { GenreID = 5, Description = "Terror" },
                new Genre { GenreID = 6, Description = "Guerra" }
            };

            var authors = new List<Author>
            {
              new Author { AuthorID = 1, Name = "John Doe" },
              new Author { AuthorID = 2, Name = "Jane Doe" },
              new Author { AuthorID = 3, Name = "Jim Starlin" },
              new Author { AuthorID = 4, Name = "Gail Simone" },
              new Author { AuthorID = 5, Name = "Warren Ellis" },
              new Author { AuthorID = 6, Name = "Jack Kirby" },
              new Author { AuthorID = 7, Name = "Jonathan Hickman" }
            };

            modelBuilder.Entity<Author>().HasData(authors);
            modelBuilder.Entity<Genre>().HasData(genres);
        }
        public ComicStoreDbContext(DbContextOptions<ComicStoreDbContext> options) : base(options) { }
        public DbSet<Comic> Comic { get; set; }
        public DbSet<Author> Author { get; set; }
        public DbSet<Genre> Genre { get; set; }
        public DbSet<ComicInventory> ComicInventory { get; set; }
        public DbSet<ComicImage> ComicImage { get; set; }
    }
}
