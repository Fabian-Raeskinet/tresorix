using Tresorix.Domain.Platform;

var sp500AccAsset = new Asset("S&P500 x Acc", "SP500", 534.93, 10.0);
var sp500Asset = new Asset("S&P500", "SP500", 50.34, 10.0);
var sp500EsgAsset = new Asset("S&P500 ESG", "SP500", 69.51, 10.0);
var nasdaqAsset = new Asset("Nasdaq", "Nas", 1002.90, 15.0);

var bitpanda = new Platform("Bitpanda");

bitpanda.AddAsset(sp500AccAsset);
bitpanda.AddAsset(sp500Asset);
bitpanda.AddAsset(sp500EsgAsset);
bitpanda.AddAsset(nasdaqAsset);

bitpanda.AddTransaction(new Transaction(new DateTime(2024, 8, 20, 10, 11, 26), 350, TransactionType.Buy, sp500AccAsset,
    537.82));
bitpanda.AddTransaction(new Transaction(new DateTime(2024, 9, 9, 13, 38, 22), 350, TransactionType.Buy, sp500AccAsset,
    524.26));
bitpanda.AddTransaction(new Transaction(new DateTime(2024, 8, 7, 12, 28, 28), 350, TransactionType.Buy, sp500Asset,
    48.60));
bitpanda.AddTransaction(new Transaction(new DateTime(2024, 8, 7, 12, 29, 42), 350, TransactionType.Buy, sp500EsgAsset,
    67.11));
bitpanda.AddTransaction(new Transaction(new DateTime(2024, 8, 12, 13, 46, 54), 50, TransactionType.Buy, nasdaqAsset,
    975.17));
bitpanda.AddTransaction(new Transaction(new DateTime(2024, 8, 19, 13, 46, 56), 50, TransactionType.Buy, nasdaqAsset,
    1015.27));
bitpanda.AddTransaction(new Transaction(new DateTime(2024, 8, 26, 13, 47, 37), 50, TransactionType.Buy, nasdaqAsset,
    1012.26));
bitpanda.AddTransaction(new Transaction(new DateTime(2024, 9, 2, 13, 47, 13), 50, TransactionType.Buy, nasdaqAsset,
    1014.27));
bitpanda.AddTransaction(new Transaction(new DateTime(2024, 9, 12, 10, 22, 14), 50, TransactionType.Buy, nasdaqAsset,
    1004.72));


var profit = bitpanda.CalculateTotalProfitOrLoss();
var wallet = bitpanda.CalculateTotalWallet();
var totalInvestment = bitpanda.CalculateTotalInvestment();

Console.WriteLine($"Profit : {profit}€");
Console.WriteLine($"Wallet : {wallet}€");
Console.WriteLine($"Investment : {totalInvestment}€");

var years = new int[] { 1, 2, 3, 4, 5 };
var futureValues = bitpanda.SimulateTransactionGrow(years);
var futurePercentage = bitpanda.SimulateNetPercentageGrow(years);

foreach (var year in years)
{
    Console.WriteLine($"Dans {year} ans :");
    Console.WriteLine($"  Valeur estimée : {futureValues[year]} €");
    Console.WriteLine($"  Pourcentage de changement : {futurePercentage[year]} %");
}

Console.WriteLine();