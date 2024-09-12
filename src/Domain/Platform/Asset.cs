namespace Tresorix.Domain.Platform;

public class Asset(string name, string? ticker, decimal actualValue) : Entity<Guid>
{
    public string? Name { get; private set; } = name;
    public string? Ticker { get; private set; } = ticker;
    public decimal ActualValue { get; private set; } = actualValue;
    public Guid PlatformId { get; set; }
    public virtual Platform? Platform { get; init; }

    public void UpdateActualValue(decimal newValue)
    {
        if (newValue < 0)
            throw new InvalidOperationException("Cannot be less than 0");
        ActualValue = newValue;
    }
}