using Front.Models;

namespace Front.Services;

public interface IAssetService
{
    Task<Asset?> GetByTicker(string ticker);
}