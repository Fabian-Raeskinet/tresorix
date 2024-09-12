namespace Tresorix.Domain.Platform;

public class Transaction(DateTime date, double amount, TransactionType type, Asset asset, double priceAtBuy) : Entity<Guid>
{
    public DateTime Date { get; private set; } = date;
    public double Amount { get; private set; } = amount;
    public double Quantity { get; } = amount / priceAtBuy;
    public double PriceAtBuy { get; } = priceAtBuy;
    public TransactionType Type { get; private set; } = type;
    public Asset Asset { get; set; } = asset;
}