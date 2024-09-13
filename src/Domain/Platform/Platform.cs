namespace Tresorix.Domain.Platform;

public class Platform(string name) : AggregateRoot<Guid>
{
    public string Name { get; } = name;
    private readonly List<Asset> _assets = new();
    public IReadOnlyCollection<Asset> Assets => _assets.AsReadOnly();
    private readonly List<Transaction> _transactions = new();
    public IReadOnlyCollection<Transaction> Transactions => _transactions.AsReadOnly();

    public void AddAsset(Asset asset)
    {
        _assets.Add(asset);
    }

    public void AddTransaction(Transaction transaction)
    {
        var platformAsset = _assets.FirstOrDefault(x => x == transaction.Asset);
        if (platformAsset is null)
        {
            throw new InvalidOperationException("Asset not found on this platform.");
        }

        _transactions.Add(transaction);
    }

    public double CalculateTotalWallet()
    {
        var totalWallet = _transactions.Sum(transaction => transaction.Amount);

        return totalWallet + CalculateTotalProfitOrLoss();
    }

    public double CalculateTotalProfitOrLoss()
    {
        return _transactions.Sum(transaction => (transaction.Asset.ActualValue - transaction.PriceAtBuy) * transaction.Quantity);
    }

    public double CalculateTotalInvestment()
    {
        return _transactions.Sum(transaction => transaction.Amount);
    }
}