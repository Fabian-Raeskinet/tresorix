using Tresorix.Domain.Platform;

namespace Tresorix.Services.Assets;

public class CreateNewAssetCommandHandler(IAssetRepository assetRepository)
    : ICommandHandler<CreateNewAssetCommandRequest>
{
    public IAssetRepository AssetRepository { get; set; } = assetRepository;

    public async Task Handle(CreateNewAssetCommandRequest request, CancellationToken cancellationToken)
    {
        var asset = new Asset(request.Name, request.Ticker, request.ActualValue,
            request.AverageYearlyPerformancePercent);
        
        await AssetRepository.CreateAsync(asset);
    }
}