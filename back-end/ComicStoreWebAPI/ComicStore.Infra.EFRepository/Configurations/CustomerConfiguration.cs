using ComicStore.Domain.POCO;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace ComicStore.Infra.EFRepository.Mapping
{
    public class CustomerConfiguration : IEntityTypeConfiguration<Customer>
    {
        public void Configure(EntityTypeBuilder<Customer> builder)
        {
            _ = builder.HasKey(c => c.CustomerID);

            _ = builder.Property(c => c.UserID).IsRequired()
                                               .HasMaxLength(450);

            _ = builder.OwnsOne(c => c.Address, d =>
            {
                d.Property(e => e.Line1).HasColumnName("Line1")
                                        .HasMaxLength(100);

                d.Property(e => e.Line2).HasColumnName("Line2")
                                        .HasMaxLength(100);

                d.Property(e => e.Number).HasColumnName("Number");

                d.Property(e => e.State).HasColumnName("State")
                                        .HasMaxLength(100);

                d.Property(e => e.PostalCode).HasColumnName("PostalCode")
                                             .HasMaxLength(8);

                d.Property(e => e.Country).HasColumnName("Country")
                                          .HasMaxLength(100);
            });
        }
    }
}
