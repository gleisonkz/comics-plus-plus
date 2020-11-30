using ComicStore.Domain.POCO;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace ComicStore.Infra.EFRepository.Mapping
{
    public class ComicImageConfiguration : IEntityTypeConfiguration<ComicImage>
    {
        public void Configure(EntityTypeBuilder<ComicImage> builder)
        {
            builder.HasKey(c => c.ComicID);

            _ = builder.HasOne(c => c.Comic)
                       .WithOne();



        }
    }
}
