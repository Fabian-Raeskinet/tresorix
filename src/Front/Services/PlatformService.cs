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
            })
            .ToList();
    }

    public async Task<Platform> GetByName(string name)
    {
        var response = await _httpClient.GetFromJsonAsync<PlatformResponse>($"api/Platform/GetByName/{name}");
        return new Platform
        {
            Id = response!.Id,
            Name = response.Name,
            TotalWallet = response.TotalWallet,
            TotalProfit = response.TotalProfit,
            TotalInvestment = response.TotalInvestment,
            PercentageProfit = response.PercentageProfit,
            Assets = response.Assets.Select(a => new Asset
                {
                    Id = a.Id,
                    Name = a.Name,
                    Ticker = a.Ticker,
                    ActualValue = a.ActualValue,
                    AverageYearlyPerformancePercent = a.AverageYearlyPerformancePercent
                })
                .ToList()
        };
    }

    public async Task<List<PlatformPredictionResponse>?> GetPredictionByPlatformId(Guid id, string query)
    {
        var response = await _httpClient.GetFromJsonAsync<PlatformPredictionResponse[]>($"api/Platform/{id}?{query}");
        return response?.ToList();
    }

    public async Task CreateNewPlatform(Platform platform)
    {
        if (platform.Name is not null)
        {
            var newPlatformCommand = new CreateNewPlatformCommand()
            {
                Name = platform.Name,
            };
            await _httpClient.PostAsJsonAsync("api/Platform", newPlatformCommand);
        }
    }

    public Task DeleteAsync(Guid id)
    {
        
        return _httpClient.DeleteAsync($"api/Platform/{id}");
    }
}