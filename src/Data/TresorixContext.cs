using Microsoft.EntityFrameworkCore;
using Tresorix.Domain.Platform;

namespace Tresorix.Data;

public class TresorixContext : DbContext, ITresorixContext
{

    public TresorixContext( DbContextOptions<TresorixContext> options) : base(options)
    {
        
    }

    public DbSet<Platform> Platforms => Set<Platform>();
    public DbSet<Asset> Assets => Set<Asset>();
    public DbSet<Transaction> Transactions => Set<Transaction>();
    
    public async Task<int> SaveChangesAsync()
    {
        return await base.SaveChangesAsync();
    }
}