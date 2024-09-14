using System.Reflection;
using Microsoft.EntityFrameworkCore;
using Tresorix.Data.Configurations.Assets;
using Tresorix.Domain.Platform;

namespace Tresorix.Data;

public class TresorixContext : DbContext, ITresorixContext
{
    public TresorixContext(DbContextOptions<TresorixContext> options) : base(options)
    {
    }

    public DbSet<Platform> Platforms => Set<Platform>();
    public DbSet<Asset> Assets => Set<Asset>();
    public DbSet<Transaction> Transactions => Set<Transaction>();

    protected override void OnModelCreating(ModelBuilder builder)
    {
        builder.ApplyConfigurationsFromAssembly(Assembly.GetAssembly(typeof(AssetConfiguration))!);

        base.OnModelCreating(builder);
    }

    public async Task<int> SaveChangesAsync()
    {
        return await base.SaveChangesAsync();
    }
}