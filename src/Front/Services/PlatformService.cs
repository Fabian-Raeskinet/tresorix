using System.Net.Http.Json;
using Front.Models;
using Tresorix.Contracts.Assets;
using Tresorix.Contracts.Platforms;

namespace Front.Services;

public class PlatformService(HttpClient httpClient) : IPlatformService
{
    private readonly HttpClient _httpClient = httpClient;

    public async Task<List<Platform>?> GetAllAsync()
    {
        var response = await _httpClient.GetFromJsonAsync<List<PlatformResponse>>("api/Platform");

        // map the models
        return response?.Select(p => new Platform
            {
                Id = p.Id,
                Name = p.Name,
                TotalWallet = p.TotalWallet,
                TotalProfit = p.TotalProfit,
                TotalInvestment = p.TotalInvestment,
                PercentageProfit = p.PercentageProfit,
                Assets =
                    p.Assets.Select(a => new Asset
                        {
                            Id = a.Id,
                            Name = a.Name,
                            Ticker = a.Ticker,
                            ActualValue = a.ActualValue,
                            AverageYearlyPerformancePercent = a.AverageYearlyPerformancePercent
                        })
                        .ToList(),
                Transactions = p.Transactions.Select(t => new Transaction
                    {
                        Date = t.Date,
                        Amount = t.Amount,
                        Quantity = t.Quantity,
                        PriceAtBuy = t.PriceAtBuy,
                        Type = TransactionType.Buy, // Assuming all transactions are of type Buy
                    })
                    .ToList()
            })
            .ToList();
    }

    public async Task<List<PlatformPredictionResponse>?> GetPredictionByPlatformId(Guid id, string query)
    {
        var response = await _httpClient.GetFromJsonAsync<PlatformPredictionResponse[]>($"api/Platform/{id}?{query}");
        return response?.ToList();
    }

    public async Task AddAssetAsync(CreateNewAssetCommand assetCommand)
    {
        await _httpClient.PostAsJsonAsync("api/Asset", assetCommand);
    }
}