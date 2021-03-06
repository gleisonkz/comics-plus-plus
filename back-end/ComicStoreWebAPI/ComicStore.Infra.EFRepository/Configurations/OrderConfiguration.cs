﻿using ComicStore.Domain.POCO;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace ComicStore.Infra.EFRepository.Mapping
{
    public class OrderConfiguration : IEntityTypeConfiguration<Order>
    {
        public void Configure(EntityTypeBuilder<Order> builder)
        {
            _ = builder.HasKey(c => c.OrderID);

            _ = builder.OwnsOne(c => c.Address, d =>
            {
                d.Property(e => e.Line1).HasColumnName("Line1")
                                        .HasMaxLength(100);

                d.Property(e => e.Line2).HasColumnName("Line2")
                                        .HasMaxLength(100);

                d.Property(e => e.Number).HasColumnName("Number");

                d.Property(e => e.City).HasColumnName("City")
                                       .HasMaxLength(100);

                d.Property(e => e.Neighborhood).HasColumnName("Neighborhood")
                                               .HasMaxLength(100);

                d.Property(e => e.State).HasColumnName("State")
                                        .HasMaxLength(100);

                d.Property(e => e.PostalCode).HasColumnName("PostalCode")
                                             .HasMaxLength(8);
            });
        }
    }
}
