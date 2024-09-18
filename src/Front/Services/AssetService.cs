using System.Net.Http.Json;
using Tresorix.Contracts.Assets;
using Tresorix.Contracts.Platforms;

namespace Front.Services;

public class AssetService(HttpClient httpClient) : IAssetService
{
    private readonly HttpClient _httpClient = httpClient;

    public async Task<AssetResponse?> GetByTicker(string ticker)
    {
        return await _httpClient.GetFromJsonAsync<AssetResponse>($"api/Asset/GetByTicker?ticker={ticker}");
    }
}