namespace Tresorix.Domain.Platform;

public interface IAssetRepository
{
    Task<Asset> GetById(Guid id);
    Task<Asset?> GetByTicker(string ticker);
    Task CreateAsync(Asset asset);
    Task<IEnumerable<Asset>> GetAllAsync();
}