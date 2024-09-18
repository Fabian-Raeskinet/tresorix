using Tresorix.Contracts.Assets;

namespace Front.Services;

public interface IAssetService
{
    Task<AssetResponse?> GetByTicker(string ticker);
}