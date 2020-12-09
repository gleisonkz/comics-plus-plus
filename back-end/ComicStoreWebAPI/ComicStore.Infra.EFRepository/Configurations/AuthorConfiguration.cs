using ComicStore.Domain.POCO;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace ComicStore.Infra.EFRepository.Mapping
{
    public class AuthorConfiguration : IEntityTypeConfiguration<Author>
    {
        public void Configure(EntityTypeBuilder<Author> builder)
        {
            builder.HasKey(c => c.AuthorID);

            _ = builder.Property(c => c.Name)
                       .IsRequired()
                       .HasMaxLength(100);

            builder.HasData(
                          new Author { AuthorID = 1, Name = "John Doe" },
                          new Author { AuthorID = 2, Name = "Jane Doe" },
                          new Author { AuthorID = 3, Name = "Jim Starlin" },
                          new Author { AuthorID = 4, Name = "Gail Simone" },
                          new Author { AuthorID = 5, Name = "Warren Ellis" },
                          new Author { AuthorID = 6, Name = "Jack Kirby" },
                          new Author { AuthorID = 7, Name = "Jonathan Hickman" }
                      );
        }
    }
}
