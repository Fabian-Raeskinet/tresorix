using Tresorix.Domain.Platform;

namespace Tresorix.Services.Assets;

public class CreateNewAssetCommandHandler(IAssetRepository assetRepository, IUnitOfWork unitOfWork)
    : ICommandHandler<CreateNewAssetCommandRequest>
{
    public IUnitOfWork UnitOfWork { get; set; } = unitOfWork;

    public async Task Handle(CreateNewAssetCommandRequest request, CancellationToken cancellationToken)
    {
        var asset = new Asset(request.Name, request.Ticker, request.ActualValue,
            request.AverageYearlyPerformancePercent);

        await UnitOfWork.AssetRepository.CreateAsync(asset);
        await UnitOfWork.CommitAsync();
    }
}