using Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Infra.Database.Map;

public class AssetMap : IEntityTypeConfiguration<Asset>
{
    public void Configure(EntityTypeBuilder<Asset> builder)
    {
        builder.ToTable("ATIVO");

        builder.HasKey(x => x.Id);

        builder.Property(x => x.Id)
            .HasColumnName("COD_ATIVO");

        builder.Property(x => x.Symbol)
            .HasColumnName("NOM_SIMBOLO")
            .HasMaxLength(20)
            .IsRequired();

        builder.Property(x => x.Name)
            .HasColumnName("NOM_ATIVO")
            .HasMaxLength(100)
            .IsRequired();

        builder.Property(x => x.AvailableQuantity)
          .HasColumnName("VAL_QUANTIDADE_DISPONIVEL")
          .IsRequired();

        builder.Property(x => x.Price)
           .HasColumnName("VAL_PRECO")
           .HasPrecision(18,2)
           .IsRequired();

        builder.Property(x => x.MarketValue)
           .HasColumnName("VAL_MERCADO")
           .HasPrecision(18, 2)
           .IsRequired();
    }
}
