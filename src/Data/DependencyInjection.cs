using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Tresorix.Data.Assets;
using Tresorix.Domain.Platform;

namespace Tresorix.Data;

public static class DependencyInjection
{
    public static IServiceCollection AddInfrastructureServices(this IServiceCollection services,
        IConfiguration configuration)
    {
        return services
            .AddRepositories()
            .AddDatabaseConfiguration(configuration);
    }

    private static IServiceCollection AddRepositories(this IServiceCollection services)
    {
        services.AddScoped<IAssetRepository, AssetRepository>();
        services.AddScoped<IPlatformRepository, PlatformRepository>();

        return services;
    }

    private static IServiceCollection AddDatabaseConfiguration(this IServiceCollection services,
        IConfiguration configuration)
    {
        services.AddDbContext<TresorixContext>(options =>
            options.UseSqlServer(configuration.GetConnectionString("DefaultConnection")));

        services.AddScoped<ITresorixContext>(provider => provider.GetRequiredService<TresorixContext>());

        services.AddScoped<TresorixContextInitializer>();

        return services;
    }
}