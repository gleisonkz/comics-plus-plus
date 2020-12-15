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

            _ = builder.Property(c => c.Title)
                 .IsRequired()
                 .HasMaxLength(100);

            _ = builder.Property(c => c.Description)
                 .IsRequired()
                 .HasMaxLength(500);

            _ = builder.Property(c => c.Price)
                 .IsRequired();

            _ = builder.Property(c => c.Pages)
                 .IsRequired();
        }
    }
}
