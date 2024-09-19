using Tresorix.Contracts.Platforms;

namespace Tresorix.Services.Platforms;

public class GetPlatformByNameQueryRequest : IQuery<PlatformResponse>
{
    public required string Name { get; set; }
}