using Tresorix.Contracts.Assets;
using Tresorix.Contracts.Platforms;
using Tresorix.Contracts.Transactions;

namespace Tresorix.Services.Platforms;

public class GetPlatformByNameQueryHandler(IUnitOfWork unitOfWork) : IQueryHandler<GetPlatformByNameQueryRequest, PlatformResponse>
{
    private IUnitOfWork UnitOfWork { get; } = unitOfWork;

    public async Task<PlatformResponse> Handle(GetPlatformByNameQueryRequest request, CancellationToken cancellationToken)
    {
        var platform = await UnitOfWork.PlatformRepository.GetByName(request.Name);

        return new PlatformResponse
        {
            Id = platform.Id,
            Name = platform.Name,
            TotalWallet = platform.CalculateTotalWallet(),
            TotalProfit = platform.CalculateTotalProfitOrLoss(),
            TotalInvestment = platform.CalculateTotalInvestment(),
            PercentageProfit = platform.CalculateProfitPercentage(),
            Assets = platform.Assets.Select(asset => new AssetResponse
                {
                    Id = asset.Id,
                    Name = asset.Name,
                    Ticker = asset.Ticker,
                    ActualValue = asset.ActualValue,
                    AverageYearlyPerformancePercent = asset.AverageYearlyPerformancePercent
                })
                .ToList(),
            Transactions = platform.Transactions.Select(transaction => new TransactionResponse
                {
                    Id = transaction.Id,
                    Date = transaction.Date,
                    Amount = transaction.Amount,
                    Quantity = transaction.Quantity,
                    PriceAtBuy = transaction.PriceAtBuy
                })
                .ToList()
        };
    }
}