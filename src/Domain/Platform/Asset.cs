namespace Tresorix.Domain.Platform;

public class Asset(string name, List<Transaction> transactions, string? ticker, decimal actualValue) : Entity<Guid>
{
    public string? Name { get; private set; } = name;
    public string? Ticker { get; private set; } = ticker;
    public decimal ActualValue { get; private set; } = actualValue;
    public virtual required Platform Platform { get; init; }


}