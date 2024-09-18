using Tresorix.Contracts.Assets;

namespace Tresorix.Services.Assets;

public class GetAssetByTickerQueryHandler(IUnitOfWork unitOfWork) : IQueryHandler<GetAssetByTickerQueryRequest, AssetResponse>
{
    private IUnitOfWork UnitOfWork { get; set; } = unitOfWork;

    public async Task<AssetResponse> Handle(GetAssetByTickerQueryRequest request, CancellationToken cancellationToken)
    {
        var asset = await UnitOfWork.AssetRepository.GetByTicker(request.Ticker);

        if (asset is null)
            throw new InvalidOperationException();

        return new AssetResponse
        {
            Id = asset.Id,
            Name = asset.Name,
            Ticker = asset.Ticker,
            ActualValue = asset.ActualValue,
            AverageYearlyPerformancePercent = asset.AverageYearlyPerformancePercent
        };
    }
}