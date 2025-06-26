using System.Reflection;
using Cash.DAC.Attributes;
using Microsoft.Extensions.DependencyInjection;

namespace Cash.DAC;

public static class DependencyInjection
{
    public static IServiceCollection AddRepositories(this IServiceCollection services)
    {
        Assembly assembly = typeof(RepositoryAttribute).Assembly;
        services.Scan(scan => scan.FromAssemblies(assembly)
            .AddClasses(c => c.WithAttribute<RepositoryAttribute>())
            .AsImplementedInterfaces()
            .WithScopedLifetime()  
        );
        return services;
    }
}