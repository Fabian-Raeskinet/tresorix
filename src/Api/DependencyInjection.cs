using Newtonsoft.Json.Converters;
using Tresorix.Api.Filters;

namespace Tresorix.Api;

public static class DependencyInjection
{
    public static void AddApiServices(this IServiceCollection services, IConfiguration configuration)
    {
        services.AddEndpointsApiExplorer();
        services.AddMvcConfiguration();
        services.AddControllerConfiguration();
        services.AddSwaggerConfiguration();
    }

    private static void AddMvcConfiguration(this IServiceCollection services)
    {
        services.AddMvc(options =>
        {
            options.Filters.Add<ApiExceptionFilterAttribute>();
        });
    }

    private static void AddControllerConfiguration(this IServiceCollection services)
    {
        services.AddControllers()
            .ConfigureApiBehaviorOptions(options => options.SuppressModelStateInvalidFilter = true)
            .AddNewtonsoftJson(options => { options.SerializerSettings.Converters.Add(new StringEnumConverter()); });
    }

    private static void AddSwaggerConfiguration(this IServiceCollection services)
    {
        services.AddSwaggerGen();
        services.AddSwaggerGenNewtonsoftSupport();
    }
    
}