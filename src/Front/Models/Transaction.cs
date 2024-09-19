namespace Front.Models;

public class Transaction
{
    public required DateTime Date { get;  set; }
    public required double Amount { get;  set; }
    public required double Quantity { get; set; }
    public required double PriceAtBuy { get; set; }
    public TransactionType Type { get; set; }
}