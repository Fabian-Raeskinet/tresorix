using System.Net.Http.Json;
using Tresorix.Contracts.Assets;
using Tresorix.Contracts.Platforms;

namespace Front.Services;

public class PlatformService(HttpClient httpClient) : IPlatformService
{
    private readonly HttpClient _httpClient = httpClient;

    public async Task<List<PlatformResponse>?> GetAllAsync()
    {
        return await _httpClient.GetFromJsonAsync<List<PlatformResponse>>("api/Platform");
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