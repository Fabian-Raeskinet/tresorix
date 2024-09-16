using Tresorix.Domain.Platform;

namespace Tresorix.Data;

public class PlatformRepository(ITresorixContext context) : IPlatformRepository
{
    public ITresorixContext Context { get; set; } = context;

    public async Task UpdateAsync(Platform platform)
    {
        Context.Platforms.Update(platform);
        await SaveChanges();
    }
    
    private async Task SaveChanges()
    {
        await Context.SaveChangesAsync();
    }
}