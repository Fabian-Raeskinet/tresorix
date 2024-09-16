using Tresorix.Contracts.Assets;
using Tresorix.Contracts.Transactions;

namespace Tresorix.Contracts.Platforms;

public record PlatformResponse
{
    public Guid Id { get; set; }
    public required string Name { get; set; }
    public required List<AssetResponse> Assets { get; set; }
    public required List<TransactionResponse> Transactions { get; set; }
}