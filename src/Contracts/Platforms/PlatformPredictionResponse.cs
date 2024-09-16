namespace Tresorix.Contracts.Platforms;

public record PlatformPredictionResponse
{
    public int Year { get; set; }
    public double EstimatedAmount { get; set; }
    public double EstimatedPercentageChange { get; set; }
}