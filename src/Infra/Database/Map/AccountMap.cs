using Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Infra.Database.Map;

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
