namespace Tresorix.Domain.Platform;

public interface IPlatformRepository
{
    Task<IEnumerable<Platform>> GetAll();
    Task<Platform> GetById(Guid id);
    Task<Platform> GetByName(string name);
    void UpdateAsync(Platform platform);
    Task CreateAsync(Platform platform);
    void DeleteAsync(Platform platform);
}