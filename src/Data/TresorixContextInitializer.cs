using Microsoft.EntityFrameworkCore;
using Tresorix.Domain.Platform;

namespace Tresorix.Data;

public class TresorixContextInitializer(TresorixContext context)
{
    private TresorixContext Context { get; set; } = context;

    public async Task InitialiseAsync()
    {
        if (Context.Database.IsSqlServer())
            await Context.Database.MigrateAsync();
    }

    public async Task TrySeedAsync()
    {
        if (!Context.Assets.Any())
        {
            var sp500AccAsset = new Asset("S&P500 x Acc", "SP500", 534.93, 10.0);
            var sp500Asset = new Asset("S&P500", "SP500", 50.34, 10.0);
            var sp500EsgAsset = new Asset("S&P500 ESG", "SP500", 69.51, 10.0);
            var nasdaqAsset = new Asset("Nasdaq", "Nas", 1002.90, 15.0);

            var platform = new Platform("Bitpanda");
            
            platform.AddAsset(sp500AccAsset);
            platform.AddAsset(sp500Asset);
            platform.AddAsset(sp500EsgAsset);
            platform.AddAsset(nasdaqAsset);

            Context.Assets.AddRange(sp500AccAsset, sp500Asset, sp500EsgAsset, nasdaqAsset);
            
            platform.AddTransaction(new Transaction(new DateTime(2024, 8, 20, 10, 11, 26), 350, TransactionType.Buy,
                sp500AccAsset,
                537.82));
            platform.AddTransaction(new Transaction(new DateTime(2024, 9, 9, 13, 38, 22), 350, TransactionType.Buy,
                sp500AccAsset,
                524.26));
            platform.AddTransaction(new Transaction(new DateTime(2024, 8, 7, 12, 28, 28), 350, TransactionType.Buy,
                sp500Asset, 48.60));
            platform.AddTransaction(new Transaction(new DateTime(2024, 8, 7, 12, 29, 42), 350, TransactionType.Buy,
                sp500EsgAsset, 67.11));
            platform.AddTransaction(new Transaction(new DateTime(2024, 8, 12, 13, 46, 54), 50, TransactionType.Buy,
                nasdaqAsset, 975.17));
            platform.AddTransaction(new Transaction(new DateTime(2024, 8, 19, 13, 46, 56), 50, TransactionType.Buy,
                nasdaqAsset, 1015.27));
            platform.AddTransaction(new Transaction(new DateTime(2024, 8, 26, 13, 47, 37), 50, TransactionType.Buy,
                nasdaqAsset, 1012.26));
            platform.AddTransaction(new Transaction(new DateTime(2024, 9, 2, 13, 47, 13), 50, TransactionType.Buy,
                nasdaqAsset, 1014.27));
            platform.AddTransaction(new Transaction(new DateTime(2024, 9, 12, 10, 22, 14), 50, TransactionType.Buy,
                nasdaqAsset, 1004.72));
            Context.Platforms.Add(platform);

            var tradeRepublic = new Platform("Trade Republic");

            Context.Platforms.Add(tradeRepublic);
            
            tradeRepublic.AddAsset(nasdaqAsset);
            
            tradeRepublic.AddTransaction(new Transaction(DateTime.Now, 50, TransactionType.Buy, nasdaqAsset, 1000));

            await Context.SaveChangesAsync();
        }
    }
}