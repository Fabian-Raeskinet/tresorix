using Tresorix.Domain.Platform;

var appleAsset = new Asset("Apple Inc.", "AAPL", 100);
appleAsset.Id = Guid.NewGuid();
var unknownAsset = new Asset("xxx", "xxx", 0);

var bitpandaPlatform = new Platform("BitPanda");
var tradeRepublicPlatform = new Platform("TradeRepublic");

bitpandaPlatform.AddAsset(appleAsset);
tradeRepublicPlatform.AddAsset(appleAsset);

appleAsset.UpdateActualValue(537.82);

bitpandaPlatform.AddTransaction(new Transaction(DateTime.Now, 350, TransactionType.Buy, appleAsset));

appleAsset.UpdateActualValue(524.26);

bitpandaPlatform.AddTransaction(new Transaction(DateTime.Now, 350, TransactionType.Buy, appleAsset));
appleAsset.UpdateActualValue(532.95);

var profit = bitpandaPlatform.CalculateTotalProfitOrLoss();

Console.WriteLine();