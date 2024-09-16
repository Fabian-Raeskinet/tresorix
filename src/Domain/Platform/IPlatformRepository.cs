namespace Tresorix.Domain.Platform;

public interface IPlatformRepository
{
    Task<IEnumerable<Platform>> GetAll();
    Task<Platform> GetById(Guid id);
    void UpdateAsync(Platform platform);
}