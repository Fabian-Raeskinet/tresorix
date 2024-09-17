using Tresorix.Contracts.Platforms;

namespace Tresorix.Services.Platforms;

public class GetPlatformEstimatedPredictionQueryHandler(IUnitOfWork unitOfWork)
    : IQueryHandler<GetPlatformPredictionQueryRequest, IEnumerable<PlatformPredictionResponse>>
{
    private IUnitOfWork UnitOfWork { get; } = unitOfWork;

    public async Task<IEnumerable<PlatformPredictionResponse>> Handle(GetPlatformPredictionQueryRequest request, CancellationToken cancellationToken)
    {
        var platform = await UnitOfWork.PlatformRepository.GetById(request.PlatformId);

        var futureValues = platform.SimulateTransactionGrow(request.Years);
        var futurePercentage = platform.SimulateNetPercentageGrow(request.Years);
        var estimatedPredictions = request.Years.Select(year =>
            new PlatformPredictionResponse { Year = year, EstimatedAmount = futureValues[year], EstimatedPercentageChange = futurePercentage[year] });
        return estimatedPredictions;
    }
}