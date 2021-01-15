using ComicStore.Domain.POCO;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace ComicStore.Infra.EFRepository.Mapping
{
    public class OrderItemConfiguration : IEntityTypeConfiguration<OrderItem>
    {
        public void Configure(EntityTypeBuilder<OrderItem> builder)
        {
            _ = builder.HasKey(c => c.OrderItemID);

            _ = builder.HasOne(c => c.Comic)
                       .WithMany()
                       .HasForeignKey(c => c.ComicID);

            _ = builder.HasOne(c => c.Order)
                       .WithMany(c => c.OrderItems)
                       .HasForeignKey(c => c.OrderID);

            _ = builder.Property(c => c.UnitValue)
                       .IsRequired()
                       .HasPrecision(7, 2);

            _ = builder.Property(c => c.TotalValue)
                       .IsRequired()
                       .HasPrecision(7, 2);
        }
    }
}
