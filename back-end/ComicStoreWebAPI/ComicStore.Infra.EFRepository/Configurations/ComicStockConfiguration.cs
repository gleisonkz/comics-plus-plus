using ComicStore.Domain.POCO;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace ComicStore.Infra.EFRepository.Mapping
{
    public class ComicStockConfiguration : IEntityTypeConfiguration<ComicStock>
    {
        public void Configure(EntityTypeBuilder<ComicStock> builder)
        {
            builder.HasKey(c => c.ComicID);

            _ = builder.HasOne(c => c.Comic)
                       .WithOne(d => d.Stock)
                       .OnDelete(DeleteBehavior.Cascade)
                       .IsRequired();
        }
    }
}
