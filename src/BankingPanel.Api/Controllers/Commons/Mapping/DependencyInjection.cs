using System.Reflection;
using Mapster;
using MapsterMapper;

namespace BankingPanel.Api.Controllers.Commons.Mapping;

public static class DependencyInjection
{
    public static IServiceCollection AddMappings(this IServiceCollection services)
    {
        // Register Mapper configration services 
        var config = TypeAdapterConfig.GlobalSettings;
        config.Scan(Assembly.GetExecutingAssembly());

        services.AddSingleton(config);
        
        services.AddScoped<IMapper, ServiceMapper>();

        return services;
    }

}
