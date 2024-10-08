namespace Tresorix.Contracts.Assets;

public record class AssetResponse
{
    public Guid Id { get; set; }
    public required string Name { get; init; }
    public required string Ticker { get; init; }
    public double ActualValue { get; init; }
    public double AverageYearlyPerformancePercent { get; init; }
}