using Tresorix.Contracts.Platforms;

namespace Tresorix.Services.Platforms;

public class GetPlatformPredictionQueryRequest : GetPlatformPredictionQuery, IQuery<IEnumerable<PlatformPredictionResponse>>
{
    public Guid PlatformId { get; set; }
}