namespace Tresorix.Contracts.Transactions;

public record TransactionResponse
{
    public Guid Id { get; set; }
    public DateTime Date { get;  init; }
    public double Amount { get; init; }
    public double Quantity { get; init; }
    public double PriceAtBuy { get; init; }
}