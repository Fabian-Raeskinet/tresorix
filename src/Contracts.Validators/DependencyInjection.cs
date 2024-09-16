using FluentValidation;
using Microsoft.Extensions.DependencyInjection;
using Tresorix.Contracts.Validators.Assets;

namespace Tresorix.Contracts.Validators;

public static class DependencyInjection
{
    private static IServiceCollection AddFluentValidationServices(this IServiceCollection services)
    {
        services.AddValidatorsFromAssemblyContaining<CreateNewAssetCommandRequestValidators>();

        return services;
    }

    public static void AddContractValidators(this IServiceCollection services)
    {
        services.AddFluentValidationServices();
    }
}