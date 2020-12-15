using ComicStore.Domain.POCO;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace ComicStore.Infra.EFRepository.Mapping
{
    public class ComicImageConfiguration : IEntityTypeConfiguration<ComicImage>
    {
        public void Configure(EntityTypeBuilder<ComicImage> builder)
        {
            _ = builder.HasKey(c => c.ComicID);

            _ = builder.Property(c => c.ComicID)
                   .HasColumnName("ComicID");

            _ = builder.HasOne(c => c.Comic)                
                       .WithOne(d=> d.Image);

            _ = builder.Property(c => c.Name)
                       .IsRequired()
                       .HasMaxLength(100);

            _ = builder.Property(c => c.Extension)
                       .IsRequired()
                       .HasMaxLength(5);

            _ = builder.Property(c => c.Base64)
                       .IsRequired();
        }
    }
}
