using Tresorix.Contracts.Platforms;

namespace Tresorix.Services.Platforms;

public class GetPlatformEstimatedPredictionQueryHandler(IUnitOfWork unitOfWork)
    : IQueryHandler<GetPlatformPredictionQueryRequest, IEnumerable<PlatformPredictionResponse>>
{
    private IUnitOfWork UnitOfWork { get; } = unitOfWork;

    public async Task<IEnumerable<PlatformPredictionResponse>> Handle(GetPlatformPredictionQueryRequest request, CancellationToken cancellationToken)
    {
        var platform = await UnitOfWork.PlatformRepository.GetById(request.PlatformId);

        var futureValues = platform.EstimateFutureValues(request.Years);
        var estimatedPredictions = futureValues.Select(kv =>
            new PlatformPredictionResponse { Year = kv.Key, EstimatedAmount = kv.Value.EstimatedValue, EstimatedPercentageChange = kv.Value.PercentageChange });
        return estimatedPredictions;
    }
}