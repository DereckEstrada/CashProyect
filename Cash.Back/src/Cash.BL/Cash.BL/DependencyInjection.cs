using System.Reflection;
using Cash.BL.Attributes;
using Microsoft.Extensions.DependencyInjection;

namespace Cash.BL;

public static  class DependencyInjection
{
    public static IServiceCollection AddServices(this IServiceCollection services)
    {
        Assembly assembly = typeof(ServiceAttribute).Assembly;
        services.Scan(scan => scan.FromAssemblies(assembly).AddClasses(c => c.WithAttribute<ServiceAttribute>())
            .AsImplementedInterfaces()
            .WithScopedLifetime()
        );
        return services;    
    }
}