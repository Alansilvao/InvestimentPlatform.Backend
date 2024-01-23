﻿using Domain.Entities;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;
using System.Diagnostics.CodeAnalysis;

namespace Infra.Database.Map;

[ExcludeFromCodeCoverage]
public class AccountMap : IEntityTypeConfiguration<Account>
{
    public void Configure(EntityTypeBuilder<Account> builder)
    {
        builder.ToTable("CONTA");

        builder.HasKey(x => x.Id);

        builder.Property(x => x.Id)
            .HasColumnName("COD_CONTA");

        builder.Property(x => x.ClientId)
            .HasColumnName("COD_CLIENTE")
            .IsRequired();

        builder.Property(x => x.Balance)
            .HasColumnName("VAL_SALDO")
            .HasPrecision(18, 2)
            .IsRequired();
    }
}
