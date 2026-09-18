using System.Reflection;
using CloudNativeKit.Core.Commands;
using CloudNativeKit.Core.Events.Extensions;
using CloudNativeKit.Core.Messages;
using CloudNativeKit.Core.Messages.Extensions;
using CloudNativeKit.Core.Paging;
using CloudNativeKit.Core.Persistence;
using CloudNativeKit.Core.Queries;
using CloudNativeKit.Core.Serialization;
using CloudNativeKit.Core.Serialization.NewtonsoftSerializer;
using Mediator;
using Microsoft.Extensions.DependencyInjection.Extensions;
using Microsoft.Extensions.Hosting;
using Sieve.Services;

namespace CloudNativeKit.Core.Extensions;

public static class DependencyInjectionExtensions
{
    public static IHostApplicationBuilder AddCoreServices(this IHostApplicationBuilder builder)
    {
        // Find assemblies that reference the current assembly
        var referencingAssemblies = Assembly.GetCallingAssembly().GetReferencingAssemblies();

        builder.Services.TryAddScoped<ISieveProcessor, ApplicationSieveProcessor>();

        builder.Services.AddDefaultSerializer();

        builder.Services.AddCommandBus();

        builder.Services.AddQueryBus();

        builder.Services.AddEvents(referencingAssemblies);

        builder.Services.AddMessages(referencingAssemblies);

        builder.Services.ScanAndRegisterDbExecutors(referencingAssemblies);

        builder.Services.TryAddScoped<IMediator, NullMediator>();

        return builder;
    }
}
