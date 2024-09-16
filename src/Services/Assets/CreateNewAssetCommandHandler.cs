using Tresorix.Domain.Platform;

namespace Tresorix.Services.Assets;

public class CreateNewAssetCommandHandler(IUnitOfWork unitOfWork) : ICommandHandler<CreateNewAssetCommandRequest>
{
    private IUnitOfWork UnitOfWork { get; } = unitOfWork;

    public async Task Handle(CreateNewAssetCommandRequest request, CancellationToken cancellationToken)
    {
        var asset = new Asset(request.Name, request.Ticker, request.ActualValue,
            request.AverageYearlyPerformancePercent);

        await UnitOfWork.AssetRepository.CreateAsync(asset);
        await UnitOfWork.CommitAsync();
    }
}