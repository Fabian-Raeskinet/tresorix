using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Tresorix.Domain.Platform;

namespace Tresorix.Data.Configurations.Assets;

public class AssetConfiguration : IEntityTypeConfiguration<Asset>
{
    public void Configure(EntityTypeBuilder<Asset> builder)
    {
        builder.HasKey(x => x.Id);
        builder.Property(x => x.Id)
            .HasValueGenerator<NewIdGenerator>();

        builder.Property(x => x.Name)
            .HasMaxLength(30)
            .IsRequired();
        
        builder.Property(x => x.Ticker)
            .HasMaxLength(30)
            .IsRequired();

        builder.HasIndex(x => x.Ticker).IsUnique();

        builder.Property(x => x.ActualValue)
            .IsRequired();

        builder.Property(x => x.AverageYearlyPerformancePercent)
            .IsRequired();

        builder.HasMany(x => x.Platforms)
            .WithMany(x => x.Assets);
    }
}