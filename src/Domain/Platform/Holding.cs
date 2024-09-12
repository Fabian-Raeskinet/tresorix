namespace Tresorix.Domain.Platform;

public class Holding(Asset asset, Platform platform)
{
    public Asset Asset { get; set; } = asset;
    public Platform Platform { get; set; } = platform;
    private readonly List<Transaction> _transactions = new();
    public IReadOnlyCollection<Transaction> Transactions => _transactions.AsReadOnly();

    public void AddTransaction(Transaction transaction)
    {
        _transactions.Add(transaction);
    }

    public decimal CalculateGlobal()
    {
        return _transactions.Sum(x => x.Amount);
    }
}