using Microsoft.EntityFrameworkCore;
using Tresorix.Domain.Platform;

namespace Tresorix.Data;

public class PlatformRepository(ITresorixContext context) : IPlatformRepository
{
    public ITresorixContext Context { get; set; } = context;

    public async Task<Platform> GetById(Guid id)
    {
        return await Context.Platforms
            .Include(x => x.Assets)
            .Include(x => x.Transactions)
            .FirstAsync(x => x.Id == id);
    }

    public void UpdateAsync(Platform platform)
    {
        Context.Platforms.Update(platform);
    }
}