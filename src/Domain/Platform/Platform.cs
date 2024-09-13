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

        return Math.Round(totalWallet + CalculateTotalProfitOrLoss(), 2);
    }

    public double CalculateTotalProfitOrLoss()
    {
        return Math.Round(_transactions.Sum(transaction =>
            (transaction.Asset.ActualValue - transaction.PriceAtBuy) * transaction.Quantity), 2);
    }

    public double CalculateTotalInvestment()
    {
        return _transactions.Sum(transaction => transaction.Amount);
    }
    
    public Dictionary<int, (double EstimatedValue, double PercentageChange)> EstimateFutureValuesWithPercentage(int[] years)
    {
        var futureValues = new Dictionary<int, (double EstimatedValue, double PercentageChange)>();

        var totalCurrentValue = CalculateTotalWallet();

        foreach (var year in years)
        {
            double totalFutureValue = 0;

            foreach (var transaction in _transactions)
            {
                var asset = transaction.Asset;
                var annualGrowthRate = asset.AveragePerformancePercent / 100;

                var futureValue = transaction.Amount * Math.Pow(1 + annualGrowthRate, year);

                totalFutureValue += futureValue;
            }

            var percentageChange = ((totalFutureValue - totalCurrentValue) / totalCurrentValue) * 100;

            futureValues[year] = (Math.Round(totalFutureValue, 2), Math.Round(percentageChange, 2));
        }

        return futureValues;
    }
}