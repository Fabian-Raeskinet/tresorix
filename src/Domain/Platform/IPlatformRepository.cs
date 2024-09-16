namespace Tresorix.Domain.Platform;

public interface IPlatformRepository
{
    Task<Platform> GetById(Guid id);
    void UpdateAsync(Platform platform);
}