using ComicStore.Domain.POCO;
using ComicStore.Shared.Classes;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Reflection;

namespace ComicStore.Infra.EFRepository.Context
{
    public class ComicStoreDbContext : DbContext
    {
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder.ApplyConfigurationsFromAssembly(Assembly.GetExecutingAssembly()));

            #region Seeding Data
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
              new Author { AuthorID = 1, Name = "John Doe" , BirthDate = Utils.RandomDay(), Nationality = "Australian"},
              new Author { AuthorID = 2, Name = "Jane Doe", BirthDate = Utils.RandomDay() , Nationality = "Dominican"},
              new Author { AuthorID = 3, Name = "JK Rowling" , BirthDate = Utils.RandomDay(), Nationality = "English"},
              new Author { AuthorID = 4, Name = "Gail Simone" , BirthDate = Utils.RandomDay(), Nationality = "Mexican"},
              new Author { AuthorID = 5, Name = "Warren Ellis" , BirthDate = Utils.RandomDay(), Nationality = "French"},
              new Author { AuthorID = 6, Name = "Jack Kirby" , BirthDate = Utils.RandomDay(), Nationality = "Indonesian"},
              new Author { AuthorID = 7, Name = "Jonathan Hickman", BirthDate = Utils.RandomDay(), Nationality = "Indian" }
            };

            var comics = new List<Comic>
            {
                new Comic {
                    ComicID = 1,
                    Title = "Hulk",
                    Pages = 200,
                    Year = 2012,
                    Price = 50.00M,
                    Description = "In his comic book appearances, the character is both the Hulk, a green-skinned, hulking and muscular humanoid possessing a vast degree of physical strength, and his alter ego Dr. Robert Bruce Banner, a physically weak, socially withdrawn, and emotionally reserved physicist.",
                },
                new Comic {
                    ComicID = 2,
                    Title = "Spider Man",
                    Pages = 99,
                    Year = 1998,
                    Price = 66.99M,
                    Description = "American teenager Peter Parker, a poor sickly orphan, is bitten by a radioactive spider. As a result of the bite, he gains superhuman strength, speed, and agility along with the ability to cling to walls.",
                },
                new Comic {
                    ComicID = 3,
                    Title = "Iron Man",
                    Pages = 77,
                    Year = 2002,
                    Price = 45.99M,
                    Description = "Iron Man is a fictional superhero appearing in American comic books published by Marvel Comics. ... He uses the suit and successive versions to protect the world as Iron Man. Although at first concealing his true identity, Stark eventually publicly reveals himself to be Iron Man.",
                },
                new Comic {
                    ComicID = 4,
                    Title = "Super Girl",
                    Pages = 85,
                    Year = 2005,
                    Price = 66.00M,
                    Description = "Created as a female counterpart to Superman, Kara Zor-El shares his super powers and vulnerability to Kryptonite. Supergirl plays a supporting role in various DC Comics publications, including Action Comics, Superman, and several comic book series unrelated to Superman.",
                },
                new Comic {
                    ComicID = 5,
                    Title = "Green Lantern",
                    Pages = 105,
                    Year = 2014,
                    Price = 77.00M,
                    Description = "Green Lantern is an ongoing American comic-book series featuring the DC Comics heroes of the same name. ... When the Silver Age Green Lantern, Hal Jordan, was introduced, the character starred in a new volume of Green Lantern starting in 1960.",
                },
                new Comic {
                    ComicID = 6,
                    Title = "Venom",
                    Pages = 135,
                    Year = 2016,
                    Price = 125.00M,
                    Description = "Venom is a fictional character appearing in American comic books published by Marvel Comics, commonly in association with Spider-Man. The character is a sentient alien symbiote with an amorphous, liquid-like form, who survives by bonding with a host, usually human.",
                },
                new Comic {
                    ComicID = 7,
                    Title = "Captain America",
                    Pages = 136,
                    Year = 1997,
                    Price = 86.00M,
                    Description = "Captain America is the alter ego of Steve Rogers, a frail young man enhanced to the peak of human perfection by an experimental serum to aid the United States government's efforts in World War II. Near the end of the war, he was trapped in ice and survived in suspended animation until he was revived in modern times.",
                },
                new Comic {
                    ComicID = 8,
                    Title = "Thor",
                    Pages = 158,
                    Year = 2012,
                    Price = 55.55M,
                    Description = "The character, which is based on the Norse deity of the same name, is the Asgardian god of thunder who possesses the enchanted hammer, Mjolnir, which grants him the ability to fly and manipulate weather amongst his other superhuman attributes.",
                },
                new Comic {
                    ComicID = 9,
                    Title = "Black Panther",
                    Pages = 258,
                    Year = 2016,
                    Price = 85.00M,
                    Description = "Black Panther is a fictional superhero appearing in American comic books published by Marvel Comics. ... Black Panther's real name is T'Challa, and he is depicted as the king and protector of the fictional African nation of Wakanda.",
                },
                new Comic {
                    ComicID = 10,
                    Title = "Ms. Marvel",
                    Pages = 200,
                    Year = 2012,
                    Price = 50.00M,
                    Description = "Marvel is the name of many fictional superheroes appearing in comic books published by Marvel Comics. The character was originally conceived as a female counterpart to Captain Marvel. Like Captain Marvel, most of the bearers of the Ms.",
                },
            };

            var comicInvetories = new List<ComicInventory>
            {
                new ComicInventory
                {
                    ComicID = 1,
                    Quantity = 1
                },
                new ComicInventory
                {
                    ComicID = 2,
                    Quantity = 0
                },
                new ComicInventory
                {
                    ComicID = 3,
                    Quantity = 1
                },
                new ComicInventory
                {
                    ComicID = 4,
                    Quantity = 0
                },
                new ComicInventory
                {
                    ComicID = 5,
                    Quantity = 9
                },
                new ComicInventory
                {
                    ComicID = 6,
                    Quantity = 0
                },
                new ComicInventory
                {
                    ComicID = 7,
                    Quantity = 1
                },
                new ComicInventory
                {
                    ComicID = 8,
                    Quantity = 3
                },
                new ComicInventory
                {
                    ComicID = 9,
                    Quantity = 5
                },
                new ComicInventory
                {
                    ComicID = 10,
                    Quantity = 3
                }
            };

            var comicsAuthors = new[]
            {
                new { ComicID = 1, AuthorID = 1 },
                new { ComicID = 2, AuthorID = 2 },
                new { ComicID = 3, AuthorID = 3 },
                new { ComicID = 4, AuthorID = 4 },
                new { ComicID = 5, AuthorID = 5 },
                new { ComicID = 6, AuthorID = 6 },
                new { ComicID = 7, AuthorID = 7 },
                new { ComicID = 8, AuthorID = 1 },
                new { ComicID = 9, AuthorID = 2 },
                new { ComicID = 10, AuthorID = 3 }
            };

            var comicsGenres = new[]
            {
                new { ComicID = 1, GenreID = 1 },
                new { ComicID = 2, GenreID = 2 },
                new { ComicID = 3, GenreID = 3 },
                new { ComicID = 4, GenreID = 4 },
                new { ComicID = 5, GenreID = 5 },
                new { ComicID = 6, GenreID = 6 },
                new { ComicID = 7, GenreID = 1 },
                new { ComicID = 8, GenreID = 2 },
                new { ComicID = 9, GenreID = 3 },
                new { ComicID = 10, GenreID = 4 }
            };
            #endregion

            _ = modelBuilder.Entity<Author>().HasData(authors);
            _ = modelBuilder.Entity<Genre>().HasData(genres);
            _ = modelBuilder.Entity<Comic>().HasData(comics);
            _ = modelBuilder.Entity("ComicAuthor").HasData(comicsAuthors);
            _ = modelBuilder.Entity("ComicGenre").HasData(comicsGenres);            
            _ = modelBuilder.Entity<ComicInventory>().HasData(comicInvetories);
        }

        public ComicStoreDbContext(DbContextOptions<ComicStoreDbContext> options) : base(options) { }
        public DbSet<Comic> Comic { get; set; }
        public DbSet<Author> Author { get; set; }
        public DbSet<Genre> Genre { get; set; }
        public DbSet<ComicInventory> ComicInventory { get; set; }
        public DbSet<ComicImage> ComicImage { get; set; }
        public DbSet<Customer> Customer { get; set; }
        public DbSet<Order> Order { get; set; }
        public DbSet<OrderItem> OrderItem { get; set; }
    }
}
