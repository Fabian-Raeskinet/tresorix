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

        transaction.SetPlatform(this);
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

    public Dictionary<int, (double EstimatedValue, double PercentageChange)> EstimateFutureValues(int[] years)
    {
        var futureValues = new Dictionary<int, (double EstimatedValue, double PercentageChange)>();
        var totalCurrentValue = CalculateTotalWallet();
        foreach (var year in years)
        {
            var totalFutureValue = CalculateTotalFutureValue(year);
            var percentageChange = CalculatePercentageChange(totalFutureValue, totalCurrentValue);
            futureValues[year] = (Math.Round(totalFutureValue, 2), Math.Round(percentageChange, 2));
        }

        return futureValues;
    }

    private double CalculateTotalFutureValue(int year)
    {
        return _transactions.Sum(transaction => CalculateFutureValue(transaction, year));
    }

    private double CalculateFutureValue(Transaction transaction, int year)
    {
        var asset = transaction.Asset;
        var annualGrowthRate = asset.AverageYearlyPerformancePercent / 100;
        return transaction.Amount * Math.Pow(1 + annualGrowthRate, year);
    }

    private double CalculatePercentageChange(double totalFutureValue, double totalCurrentValue)
    {
        return ((totalFutureValue - totalCurrentValue) / totalCurrentValue) * 100;
    }
}