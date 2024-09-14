namespace Tresorix.Domain.Platform;

public interface IAssetRepository
{
    Task CreateAsync(Asset asset);
    Task<IEnumerable<Asset>> GetAllAsync();
}