namespace Tresorix.Contracts.Assets;

public class CreateNewAssetCommand
{
    public required string Name { get; init; }
    public required string Ticker { get; init; }
    public double ActualValue { get; init; }
    public double AverageYearlyPerformancePercent { get; init; }
    public Guid PlatformId { get; set; }
}