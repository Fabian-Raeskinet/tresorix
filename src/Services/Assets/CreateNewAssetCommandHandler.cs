using Tresorix.Domain.Platform;

namespace Tresorix.Services.Assets;

public class CreateNewAssetCommandHandler(IUnitOfWork unitOfWork) : ICommandHandler<CreateNewAssetCommandRequest>
{
    private IUnitOfWork UnitOfWork { get; } = unitOfWork;

    public async Task Handle(CreateNewAssetCommandRequest request, CancellationToken cancellationToken)
    {
        var platform = await UnitOfWork.PlatformRepository.GetById(request.PlatformId);
        
        var asset = new Asset(request.Name, request.Ticker, request.ActualValue,
            request.AverageYearlyPerformancePercent);
        
        platform.AddAsset(asset);

        UnitOfWork.PlatformRepository.UpdateAsync(platform);
        await UnitOfWork.CommitAsync();
    }
}