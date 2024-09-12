namespace Tresorix.Domain.Platform;

public class Transaction(DateTime date, double amount, TransactionType type, Asset asset) : Entity<Guid>
{
    public DateTime Date { get; private set; } = date;
    public double Amount { get; private set; } = amount;
    public double Quantity { get; } = amount / asset.ActualValue;
    public double PriceAtBuy { get; } = asset.ActualValue;
    public TransactionType Type { get; private set; } = type;
    public Asset Asset { get; set; } = asset;
}