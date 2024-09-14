using System.Reflection;
using MediatR;
using Microsoft.Extensions.DependencyInjection;
using Tresorix.Domain;

namespace Tresorix.Services;

public static class DependencyInjection
{
    public static void AddApplicationServices(this IServiceCollection services)
    {
        services
            .AddMediatRServices();
    }

    private static IServiceCollection AddMediatRServices(this IServiceCollection services)
    {
        services.AddMediatR(config => config.RegisterServicesFromAssembly(Assembly.GetExecutingAssembly()));
        services.AddScoped<IDomainEventDispatcher, MediatRDomainEventDispatcher>();

        return services;
    }
}