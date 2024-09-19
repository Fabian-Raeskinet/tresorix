using Microsoft.EntityFrameworkCore;
using Tresorix.Domain.Platform;

namespace Tresorix.Data;

public class PlatformRepository(ITresorixContext context) : IPlatformRepository
{
    public ITresorixContext Context { get; set; } = context;

    public async Task<IEnumerable<Platform>> GetAll()
    {
        return await Context.Platforms
            .Include(x => x.Assets)
            .Include(x => x.Transactions).ToListAsync();
    }

    public async Task<Platform> GetById(Guid id)
    {
        return await Context.Platforms
            .Include(x => x.Assets)
            .Include(x => x.Transactions)
            .FirstAsync(x => x.Id == id);
    }

    public async Task<Platform> GetByName(string name)
    {
        return await Context.Platforms
            .Include(x => x.Assets)
            .Include(x => x.Transactions)
            .FirstAsync(x => x.Name == name);
    }

    public void UpdateAsync(Platform platform)
    {
        Context.Platforms.Update(platform);
    }

    public async Task CreateAsync(Platform platform)
    {
        await Context.Platforms.AddAsync(platform);
    }

    public void DeleteAsync(Platform platform)
    {
        Context.Platforms.Remove(platform);
    }
}