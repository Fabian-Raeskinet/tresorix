using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Tresorix.Data;

namespace DependencyInjection.Configurations;

public static class ServiceCollectionExtensions
{
    public static void RegisterApplicationServices(this IServiceCollection services, IConfiguration configuration)
    {
        services.AddInfrastructureServices(configuration);
    }
}