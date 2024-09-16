namespace Tresorix.Domain.Platform;

public interface IPlatformRepository
{
    Task UpdateAsync(Platform platform);
}