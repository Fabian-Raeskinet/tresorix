using Microsoft.EntityFrameworkCore;
using Tresorix.Domain.Platform;

namespace Tresorix.Data.Assets;

public class AssetRepository(TresorixContext context) : IAssetRepository
{
    public TresorixContext Context { get; set; } = context;
    
    public async Task<IEnumerable<Asset>> GetAllAsync()
    {
        return await Context.Assets
            .ToListAsync();
    }

    public async Task CreateAsync(Asset asset)
    {
        await Context.Assets.AddAsync(asset);
        await SaveChanges();
    }
    
    private async Task SaveChanges()
    {
        await Context.SaveChangesAsync();
    }
}