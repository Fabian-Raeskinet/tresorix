using Microsoft.EntityFrameworkCore;
using Tresorix.Domain.Platform;

namespace Tresorix.Data.Assets;

public class AssetRepository(ITresorixContext context) : IAssetRepository
{
    public ITresorixContext Context { get; set; } = context;
    
    public async Task<IEnumerable<Asset>> GetAllAsync()
    {
        return await Context.Assets
            .ToListAsync();
    }

    public async Task CreateAsync(Asset asset)
    {
        await Context.Assets.AddAsync(asset);
    }
}