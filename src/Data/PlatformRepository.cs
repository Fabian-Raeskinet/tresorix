using Tresorix.Domain.Platform;

namespace Tresorix.Data;

public class PlatformRepository(ITresorixContext context) : IPlatformRepository
{
    public ITresorixContext Context { get; set; } = context;

    public void UpdateAsync(Platform platform)
    {
        Context.Platforms.Update(platform);
    }
}