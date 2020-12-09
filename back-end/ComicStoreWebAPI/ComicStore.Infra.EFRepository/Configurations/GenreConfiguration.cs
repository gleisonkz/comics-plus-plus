using ComicStore.Domain.POCO;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace ComicStore.Infra.EFRepository.Mapping
{
    public class GenreConfiguration : IEntityTypeConfiguration<Genre>
    {
        public void Configure(EntityTypeBuilder<Genre> builder)
        {
            builder.HasKey(c => c.GenreID);

            _ = builder.Property(c => c.Description)
                 .IsRequired()
                 .HasMaxLength(200);

            builder.HasData(
                new Genre { GenreID = 1, Description = "Ação" },
                new Genre { GenreID = 2, Description = "Aventura"},
                new Genre { GenreID = 3, Description = "Drama" },
                new Genre { GenreID = 4, Description = "Comedia" },
                new Genre { GenreID = 5, Description = "Terror" },
                new Genre { GenreID = 6, Description = "Guerra" }
                );
        }
    }
}
