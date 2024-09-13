namespace Tresorix.Domain.Platform;

public class Asset(string name, string ticker, double actualValue, double averageYearlyPerformancePercent) : Entity<Guid>
{
    public string Name { get; private set; } = name;
    public string Ticker { get; private set; } = ticker;
    public double ActualValue { get; private set; } = actualValue;
    public double AverageYearlyPerformancePercent { get; set; } = averageYearlyPerformancePercent;

    public void UpdateActualValue(double newValue)
    {
        if (newValue < 0)
            throw new InvalidOperationException("Cannot be less than 0");
        ActualValue = newValue;
    }
}