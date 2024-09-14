namespace Tresorix.Domain.Platform;

public class Transaction : Entity<Guid>
{
    public Transaction(DateTime date, double amount, TransactionType type, Asset asset, double priceAtBuy)
    {
        Date = date;
        Amount = amount;
        Type = type;
        Asset = asset;
        PriceAtBuy = priceAtBuy;
        Quantity = amount / priceAtBuy;
    }
    public Transaction() { }
    public DateTime Date { get; private set; }
    public double Amount { get; private set; }
    public double Quantity { get; }
    public double PriceAtBuy { get; }
    public TransactionType Type { get; private set; }
    public Asset Asset { get; set; }
    public Platform? Platform { get; private set; }
    public Guid PlatformId { get; private set; }
    
    internal void SetPlatform(Platform platform)
    {
        Platform = platform;
        PlatformId = platform.Id;
    }
}