namespace Tresorix.Contracts.Transactions;

public class CreateNewTransactionCommand
{
    public DateTime Date { get; init; }
    public double Amount { get; init; }
    public double Quantity { get; init; }
    public double PriceAtBuy { get; init; }
    public TransactionType Type { get; init; }
    public Guid AssetId { get; init; }
    public Guid PlatformId { get; init; }
}