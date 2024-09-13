using Tresorix.Domain.Platform;

var sp500AccAsset = new Asset("S&P500 x Acc", "SP500", 534.93);
var sp500Asset = new Asset("S&P500", "SP500", 50.34);
var sp500EsgAsset = new Asset("S&P500 ESG", "SP500", 69.51);
var nasdaqAsset = new Asset("Nasdaq", "Nas", 1002.90);

var bitpanda = new Platform("Bitpanda");

bitpanda.AddAsset(sp500AccAsset);
bitpanda.AddAsset(sp500Asset);
bitpanda.AddAsset(sp500EsgAsset);
bitpanda.AddAsset(nasdaqAsset);

bitpanda.AddTransaction(new Transaction(DateTime.Now, 350, TransactionType.Buy, sp500AccAsset, 537.82));
bitpanda.AddTransaction(new Transaction(DateTime.Now, 350, TransactionType.Buy, sp500AccAsset, 524.26));
bitpanda.AddTransaction(new Transaction(DateTime.Now, 350, TransactionType.Buy, sp500Asset, 48.60));
bitpanda.AddTransaction(new Transaction(DateTime.Now, 350, TransactionType.Buy, sp500EsgAsset, 67.11));
bitpanda.AddTransaction(new Transaction(DateTime.Now, 50, TransactionType.Buy, nasdaqAsset, 975.17));
bitpanda.AddTransaction(new Transaction(DateTime.Now, 50, TransactionType.Buy, nasdaqAsset, 1015.27));
bitpanda.AddTransaction(new Transaction(DateTime.Now, 50, TransactionType.Buy, nasdaqAsset, 1012.26));
bitpanda.AddTransaction(new Transaction(DateTime.Now, 50, TransactionType.Buy, nasdaqAsset, 1014.27));
bitpanda.AddTransaction(new Transaction(DateTime.Now, 50, TransactionType.Buy, nasdaqAsset, 1004.72));

var profit = bitpanda.CalculateTotalProfitOrLoss();
var wallet = bitpanda.CalculateTotalWallet();
var totalInvestment = bitpanda.CalculateTotalInvestment();

Console.WriteLine();