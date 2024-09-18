using Front.Models;

namespace Front.Services;

public interface IAssetService
{
    Task<Asset?> GetByTickerAsync(string ticker);
    Task CreateNewAssetAsync(Asset asset,  Guid platformId);
}