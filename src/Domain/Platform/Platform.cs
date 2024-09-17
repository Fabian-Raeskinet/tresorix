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

    public double CalculateProfitPercentage()
    {
        double totalInvestment = CalculateTotalInvestment();

        double currentWalletValue = CalculateTotalWallet();

        double profitPercentage = ((currentWalletValue - totalInvestment) / totalInvestment) * 100;

        return Math.Round(profitPercentage, 2);
    }

    public Dictionary<int, double> SimulateTransactionGrow(int[] yearsToSimulate)
    {
        var simulationResults = new Dictionary<int, double>();

        foreach (var year in yearsToSimulate)
        {
            simulationResults[year] = (0);
        }

        foreach (var transaction in _transactions)
        {
            var yearsSinceTransaction = (DateTime.Now - transaction.Date).Days / 365.0;
            var yearlyPerformanceRate = 1 + transaction.Asset.AverageYearlyPerformancePercent / 100;

            foreach (var additionalYear in yearsToSimulate)
            {
                var totalYearsToSimulate = yearsSinceTransaction + additionalYear;

                var futureValue = transaction.Amount * Math.Pow(yearlyPerformanceRate, totalYearsToSimulate);

                var currentSimulatedValue = simulationResults[additionalYear] + futureValue;
                simulationResults[additionalYear] = currentSimulatedValue;
            }
        }

        return simulationResults;
    }

    public Dictionary<int, double> SimulateNetPercentageGrow(int[] yearsToSimulate)
    {
        var transactionGrow = SimulateTransactionGrow(yearsToSimulate);
        var simulationResults = new Dictionary<int, double>();

        foreach (var year in yearsToSimulate)
        {
            simulationResults[year] = 0;
        }

        double currentWalletValue = CalculateTotalWallet();
        foreach (var year in yearsToSimulate)
        {
            var simulatedValue = transactionGrow[year];

            var netIncrease = simulatedValue - currentWalletValue;

            var percentageIncrease = (netIncrease / currentWalletValue) * 100;

            simulationResults[year] = Math.Round(percentageIncrease, 2);
        }

        return simulationResults;
    }
}