using CloudNativeKit.Abstractions.Commands;
using CloudNativeKit.Abstractions.Scheduler;
using CloudNativeKit.Core.Commands.Diagnostics;
using CloudNativeKit.Core.Scheduler;

namespace CloudNativeKit.Core.Commands;

internal static class DependencyInjectionExtensions
{
    public static IServiceCollection AddCommandBus(this IServiceCollection services)
    {
        services.AddTransient<ICommandBus, CommandBus>();
        services.AddTransient<IAsyncCommandBus, AsyncCommandBus>();
        services.AddTransient<ICommandScheduler, NullCommandScheduler>();

        services.AddTransient<CommandHandlerActivity>();
        services.AddTransient<CommandHandlerMetrics>();

        return services;
    }
}
