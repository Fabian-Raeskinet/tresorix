using Front.Models;
using Tresorix.Contracts.Assets;
using Tresorix.Contracts.Platforms;

namespace Front.Services;

public interface IPlatformService
{
    Task<List<Platform>?> GetAllAsync();
    Task<Platform> GetByName(string name);
    Task<List<PlatformPredictionResponse>?> GetPredictionByPlatformId(Guid id, string query);
    Task CreateNewPlatform(Platform command);
    Task DeleteAsync(Guid id);
}