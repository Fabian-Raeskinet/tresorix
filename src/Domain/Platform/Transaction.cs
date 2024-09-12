namespace Tresorix.Domain.Platform;

public class Transaction(DateTime date, decimal amount, TransactionType type, Asset asset) : Entity<Guid>
{
    public DateTime Date { get; private set; } = date;
    public decimal Amount { get; private set; } = amount;
    private decimal PriceAtBuy { get; init; } = asset.ActualValue;
    public TransactionType Type { get; private set; } = type;
    public Asset Asset { get; set; } = asset;
}