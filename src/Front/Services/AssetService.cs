using System.Net.Http.Json;
using Front.Models;
using Tresorix.Contracts.Assets;

namespace Front.Services;

public class AssetService(HttpClient httpClient) : IAssetService
{
    private readonly HttpClient _httpClient = httpClient;

    public async Task<Asset?> GetByTickerAsync(string ticker)
    {
        var response = await _httpClient.GetFromJsonAsync<AssetResponse>($"api/Asset/GetByTicker?ticker={ticker}");

        return new Asset
        {
            Id = response!.Id,
            Name = response.Name,
            Ticker = response.Ticker,
            ActualValue = response.ActualValue,
            AverageYearlyPerformancePercent = response.AverageYearlyPerformancePercent
        };
    }

    public async Task CreateNewAssetAsync(Asset asset, Guid platformId)
    {
        if (string.IsNullOrEmpty(asset.Name) || string.IsNullOrEmpty(asset.Ticker))
            return;

        var newAssetCommand = new CreateNewAssetCommand
        {
            Name = asset.Name,
            Ticker = asset.Ticker,
            ActualValue = asset.ActualValue,
            AverageYearlyPerformancePercent = asset.AverageYearlyPerformancePercent,
            PlatformId = platformId
        };

        await _httpClient.PostAsJsonAsync("api/Asset", newAssetCommand);
    }

    public async Task DeleteAsset(Guid id)
    {
        await _httpClient.DeleteAsync($"/api/Asset/{id}");
    }
}