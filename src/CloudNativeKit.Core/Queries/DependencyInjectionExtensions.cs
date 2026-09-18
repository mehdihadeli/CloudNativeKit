using CloudNativeKit.Abstractions.Queries;
using CloudNativeKit.Core.Queries.Diagnostics;

namespace CloudNativeKit.Core.Queries;

internal static class DependencyInjectionExtensions
{
    internal static IServiceCollection AddQueryBus(this IServiceCollection services)
    {
        services.AddTransient<IQueryBus, QueryBus>();

        services.AddTransient<QueryHandlerActivity>();
        services.AddTransient<QueryHandlerMetrics>();

        return services;
    }
}
