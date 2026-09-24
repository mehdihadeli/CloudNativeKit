using CloudNativeKit.Abstractions.Persistence.EventStore;
using CloudNativeKit.Core.Extensions;
using CloudNativeKit.Persistence.EventStoreDB.Extensions;
using DotNet.Testcontainers.Builders;
using DotNet.Testcontainers.Containers;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Tests.Shared.Helpers;

namespace CloudNativeKit.Persistence.EventStoreDB.IntegrationTests.Fixtures;

public class IntegrationFixture : IAsyncLifetime
{
    private const ushort EventStoreHttpPort = 2113;
    private readonly IContainer _container;
    private readonly ServiceProvider _provider;

    public IntegrationFixture()
    {
        _container = new ContainerBuilder()
            .WithImage("eventstore/eventstore:24.10.0-jammy")
            .WithPortBinding(EventStoreHttpPort, true)
            .WithEnvironment("EVENTSTORE_INSECURE", "true")
            .WithWaitStrategy(
                Wait.ForUnixContainer()
                    .UntilHttpRequestIsSucceeded(request => request.ForPort(EventStoreHttpPort).ForPath("/health/live"))
            )
            .Build();

        _container.StartAsync().GetAwaiter().GetResult();

        var builder = Host.CreateApplicationBuilder();

        builder.AddCoreServices();
        builder.Configuration["EventStoreDbOptions:Host"] = _container.Hostname;
        builder.Configuration["EventStoreDbOptions:HttpPort"] = _container
            .GetMappedPublicPort(EventStoreHttpPort)
            .ToString();
        builder.AddEventStoreDb();
        builder.Services.AddHttpContextAccessor();

        _provider = builder.Services.BuildServiceProvider();
    }

    public IEventStore EventStore => _provider.GetRequiredService<IEventStore>();

    public ValueTask InitializeAsync()
    {
        return ValueTask.CompletedTask;
    }

    public ValueTask DisposeAsync()
    {
        _provider.Dispose();
        _container.StopAsync().GetAwaiter().GetResult();
        _container.DisposeAsync().AsTask().GetAwaiter().GetResult();
        GC.SuppressFinalize(this);
        return ValueTask.CompletedTask;
    }
}
