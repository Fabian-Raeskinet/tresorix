using Microsoft.EntityFrameworkCore;
using Tresorix.Domain.Platform;

namespace Tresorix.Data.Assets;

public class AssetRepository(ITresorixContext context) : IAssetRepository
{
    public ITresorixContext Context { get; set; } = context;

    public void Delete(Asset asset)
    {
        Context.Assets.Remove(asset);
    }

    public async Task<IEnumerable<Asset>> GetAllAsync()
    {
        return await Context.Assets
            .ToListAsync();
    }

    public async Task<Asset> GetById(Guid id)
    {
        return await Context.Assets.FirstAsync(x => x.Id == id);
    }

    public async Task<Asset?> GetByTicker(string ticker)
    {
        return await Context.Assets.FirstOrDefaultAsync(x => x.Ticker == ticker);
    }

    public async Task CreateAsync(Asset asset)
    {
        await Context.Assets.AddAsync(asset);
    }
}