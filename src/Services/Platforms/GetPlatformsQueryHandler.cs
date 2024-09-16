using Tresorix.Contracts.Assets;
using Tresorix.Contracts.Platforms;
using Tresorix.Contracts.Transactions;

namespace Tresorix.Services.Platforms;

public class GetPlatformsQueryHandler(IUnitOfWork unitOfWork) : IQueryHandler<GetPlatformsQueryRequest, IEnumerable<PlatformResponse>>
{
    private IUnitOfWork UnitOfWork { get; set; } = unitOfWork;

    public async Task<IEnumerable<PlatformResponse>> Handle(GetPlatformsQueryRequest request, CancellationToken cancellationToken)
    {
        var platforms = await UnitOfWork.PlatformRepository.GetAll();

        return platforms.Select(platform => new PlatformResponse
        {
            Id = platform.Id,
            Name = platform.Name,
            Assets = platform.Assets.Select(asset => new AssetResponse
            {
                Id = asset.Id,
                Name = asset.Name,
                Ticker = asset.Ticker,
                ActualValue = asset.ActualValue,
                AverageYearlyPerformancePercent = asset.AverageYearlyPerformancePercent,
            }).ToList(),
            Transactions = platform.Transactions.Select(transaction => new TransactionResponse
            {
                Id = transaction.Id,
                Date = transaction.Date,
                Amount = transaction.Amount,
                Quantity = transaction.Quantity,
                PriceAtBuy = transaction.PriceAtBuy
            }).ToList()
        });
    }
}