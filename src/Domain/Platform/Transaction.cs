namespace Tresorix.Domain.Platform;

public abstract class Transaction(DateTime date, decimal amount, TransactionType type) : Entity<Guid>
{
    public DateTime Date { get; private set; } = date;
    public decimal Amount { get; private set; } = amount;
    public TransactionType Type { get; private set; } = type;
}