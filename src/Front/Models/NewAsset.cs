namespace Front.Models;

public class NewAsset
{
    public string? Name { get; set; }
    public string? Ticker { get; set; }
    public double ActualValue { get; set; }
    public double AverageYearlyPerformancePercent { get; set; }
}