using Tresorix.Contracts.Assets;
using Tresorix.Contracts.Transactions;

namespace Tresorix.Contracts.Platforms;

public record PlatformResponse
{
    public Guid Id { get; set; }
    public required string Name { get; set; }
    public double TotalWallet { get; set; }
    public double TotalProfit { get; set; }
    public double TotalInvestment { get; set; }
    public double PercentageProfit { get; set; }
    public required List<AssetResponse> Assets { get; set; }
    public required List<TransactionResponse> Transactions { get; set; }
}