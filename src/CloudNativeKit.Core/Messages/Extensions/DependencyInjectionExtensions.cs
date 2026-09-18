using System.Reflection;
using CloudNativeKit.Abstractions.Messages;
using CloudNativeKit.Abstractions.Messages.MessagePersistence;
using CloudNativeKit.Abstractions.Persistence.EventStore;
using CloudNativeKit.Core.Extensions;
using CloudNativeKit.Core.Extensions.ServiceCollectionExtensions;
using Microsoft.Extensions.DependencyInjection.Extensions;
using Scrutor;

namespace CloudNativeKit.Core.Messages.Extensions;

public static class DependencyInjectionExtensions
{
    internal static void AddMessages(this IServiceCollection services, Assembly[] assemblies)
    {
        services.AddValidationOptions<MessagingOptions>();

        services.AddScoped<IMessageMetadataAccessor, MessageMetadataAccessor>();

        services.AddSingleton<IMessagePublisher, MessagePublisher>();

        // will override by messaging systems like rabbitmq - we should not use `TryAddTransient` for replacing in rabbitmq
        services.AddTransient<IExternalEventBus, NullExternalEventBus>();
        services.AddTransient<IBusDirectPublisher, NullIBusDirectPublisher>();

        AddMessageHandler(services, assemblies);

        AddPersistenceMessage(services);
    }

    private static void AddPersistenceMessage(IServiceCollection services)
    {
        services.TryAddScoped<IMessagePersistenceService, NullMessagePersistenceService>();
    }

    private static void AddMessageHandler(IServiceCollection services, Assembly[] assemblies)
    {
        services.Scan(scan =>
            scan.FromAssemblies(assemblies)
                .AddClasses(classes => classes.AssignableTo(typeof(IMessageHandler<>)))
                .UsingRegistrationStrategy(RegistrationStrategy.Append)
                .AsClosedTypeOf(typeof(IMessageHandler<>))
                .AsSelf()
                .WithLifetime(ServiceLifetime.Transient)
        );

        services.Scan(scan =>
            scan.FromAssemblies(assemblies)
                .AddClasses(classes => classes.AssignableTo(typeof(IMessageEnvelopeHandler<>)))
                .UsingRegistrationStrategy(RegistrationStrategy.Append)
                .AsClosedTypeOf(typeof(IMessageEnvelopeHandler<>))
                .AsSelf()
                .WithLifetime(ServiceLifetime.Transient)
        );

        services.Scan(scan =>
            scan.FromAssemblies(assemblies)
                .AddClasses(classes => classes.AssignableTo(typeof(IStreamEventEnvelope<>)))
                .UsingRegistrationStrategy(RegistrationStrategy.Append)
                .AsClosedTypeOf(typeof(IStreamEventEnvelope<>))
                .AsSelf()
                .WithLifetime(ServiceLifetime.Transient)
        );
    }
}
