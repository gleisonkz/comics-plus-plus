using ComicStore.Domain.POCO;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System.Collections.Generic;

namespace ComicStore.Infra.EFRepository.Mapping
{
    public class ComicConfiguration : IEntityTypeConfiguration<Comic>
    {
        public void Configure(EntityTypeBuilder<Comic> builder)
        {
            _ = builder.HasKey(c => c.ComicID);

            _ = builder.HasMany(left => left.Authors)
                       .WithMany(right => right.Comics)
                       .UsingEntity(
                            "ComicAuthor",
                            typeof(Dictionary<string, object>),
                            right => right.HasOne(typeof(Author)).WithMany().HasForeignKey("AuthorID"),
                            left => left.HasOne(typeof(Comic)).WithMany().HasForeignKey("ComicID"),
                            join => join.ToTable("ComicAuthor")
                       );

            _ = builder.HasMany(left => left.Genres)
                       .WithMany(right => right.Comics)
                       .UsingEntity(
                            "ComicGenre",
                            typeof(Dictionary<string, object>),
                            right => right.HasOne(typeof(Genre)).WithMany().HasForeignKey("GenreID"),
                            left => left.HasOne(typeof(Comic)).WithMany().HasForeignKey("ComicID"),
                            join => join.ToTable("ComicGenre")
                       );

            _ = builder.Property(c => c.Title)
                 .IsRequired()
                 .HasMaxLength(100);

            _ = builder.Property(c => c.Description)
                 .IsRequired()
                 .HasMaxLength(800);

            _ = builder.Property(c => c.Price)
                 .IsRequired();

            _ = builder.Property(c => c.Pages)
                 .IsRequired();
        }
    }
}
