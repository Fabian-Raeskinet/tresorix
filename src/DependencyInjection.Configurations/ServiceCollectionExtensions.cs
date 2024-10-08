using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Tresorix.Contracts.Validators;
using Tresorix.Data;
using Tresorix.Services;

namespace Tresorix.DependencyInjection.Configurations;

public static class ServiceCollectionExtensions
{
    public static void RegisterApplicationServices(this IServiceCollection services, IConfiguration configuration)
    {
        services.AddInfrastructureServices(configuration);
        services.AddApplicationServices();
        services.AddContractValidators();
        
        services.AddScoped<IUnitOfWork, UnitOfWork>();
    }
}