using Tresorix.Contracts.Assets;
using Tresorix.Domain.Platform;

namespace Tresorix.Services.Assets;

public class GetAssetsQueryHandler(IAssetRepository assetRepository)
    : IQueryHandler<GetAssetsQueryRequest, IEnumerable<AssetResponse>>
{
    public IAssetRepository AssetRepository { get; set; } = assetRepository;

    public async Task<IEnumerable<AssetResponse>> Handle(GetAssetsQueryRequest request,
        CancellationToken cancellationToken)
    {
        var assets = await AssetRepository.GetAllAsync();

        return assets.Select(asset => new AssetResponse
        {
            Name = asset.Name,
            Ticker = asset.Ticker,
            ActualValue = asset.ActualValue,
            AverageYearlyPerformancePercent = asset.AverageYearlyPerformancePercent
        });
    }
}