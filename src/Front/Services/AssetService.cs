using System.Net.Http.Json;
using Front.Models;
using Tresorix.Contracts.Assets;

namespace Front.Services;

public class AssetService(HttpClient httpClient) : IAssetService
{
    private readonly HttpClient _httpClient = httpClient;

    public async Task<Asset?> GetByTicker(string ticker)
    {
        var response = await _httpClient.GetFromJsonAsync<AssetResponse>($"api/Asset/GetByTicker?ticker={ticker}");

        return new Asset
        {
            Name = response!.Name,
            Ticker = response.Ticker,
            ActualValue = response.ActualValue,
            AverageYearlyPerformancePercent = response.AverageYearlyPerformancePercent
        };
    }
}