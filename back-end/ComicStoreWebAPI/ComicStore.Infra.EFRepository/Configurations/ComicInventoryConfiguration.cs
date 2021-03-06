﻿using ComicStore.Domain.POCO;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace ComicStore.Infra.EFRepository.Mapping
{
    public class ComicInventoryConfiguration : IEntityTypeConfiguration<ComicInventory>
    {
        public void Configure(EntityTypeBuilder<ComicInventory> builder)
        {
            _ = builder.HasKey(c => c.ComicID);

            _ = builder.HasOne(c => c.Comic)
                       .WithOne(d => d.Inventory)
                       .OnDelete(DeleteBehavior.Cascade)
                       .IsRequired();
        }
    }
}
