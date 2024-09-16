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
        services.AddCors(options =>
        {
            options.AddPolicy("AllowAll", builder =>
            {
                builder.WithOrigins("http://localhost:5015") // Ou l'URL de votre frontend
                    .AllowAnyHeader()
                    .AllowAnyMethod();
            });
        });
        
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