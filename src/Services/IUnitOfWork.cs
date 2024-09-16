using Tresorix.Domain.Platform;

namespace Tresorix.Services;

public interface IUnitOfWork
{
    IPlatformRepository PlatformRepository { get; }
    IAssetRepository AssetRepository { get; }
    Task<int> CommitAsync();
}