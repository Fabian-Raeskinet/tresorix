using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Tresorix.Domain.Platform;

namespace Tresorix.Data.Configurations.Platforms;

public class PlatformConfiguration : IEntityTypeConfiguration<Platform>
{
    public void Configure(EntityTypeBuilder<Platform> builder)
    {
        builder.HasKey(x => x.Id);
        builder.Property(x => x.Id)
            .HasValueGenerator<NewIdGenerator>();

        builder.Property(x => x.Name)
            .HasMaxLength(30)
            .IsRequired();

        builder.HasMany(x => x.Assets)
            .WithMany(x => x.Platforms);
        
        builder
            .HasMany(p => p.Transactions)
            .WithOne(t => t.Platform)
            .HasForeignKey(t => t.PlatformId)
            .OnDelete(DeleteBehavior.Cascade);
    }
}