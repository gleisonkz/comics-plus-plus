using ComicStore.Domain.POCO;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace ComicStore.Infra.EFRepository.Mapping
{
    public class AuthorConfiguration : IEntityTypeConfiguration<Author>
    {
        public void Configure(EntityTypeBuilder<Author> builder)
        {
            _ = builder.HasKey(c => c.AuthorID);

            _ = builder.Property(c => c.Name)
                       .IsRequired()
                       .HasMaxLength(100);
        }
    }
}
