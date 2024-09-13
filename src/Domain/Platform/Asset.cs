namespace Tresorix.Domain.Platform;

public class Asset(string name, string? ticker, double actualValue, double AveragePerformancePercent) : Entity<Guid>
{
    public string? Name { get; private set; } = name;
    public string? Ticker { get; private set; } = ticker;
    public double ActualValue { get; private set; } = actualValue;
    public double AveragePerformancePercent { get; set; } = AveragePerformancePercent;

    public void UpdateActualValue(double newValue)
    {
        if (newValue < 0)
            throw new InvalidOperationException("Cannot be less than 0");
        ActualValue = newValue;
    }
}