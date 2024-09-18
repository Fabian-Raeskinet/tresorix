using Tresorix.Contracts.Assets;
using Tresorix.Contracts.Platforms;

namespace Front.Services;

public interface IPlatformService
{
    Task<List<PlatformResponse>?> GetAllAsync();
    Task<List<PlatformPredictionResponse>?> GetPredictionByPlatformId(Guid id, string query);
    Task AddAssetAsync(CreateNewAssetCommand assetCommand);
}