using CloudNativeKit.Abstractions.Persistence.EventStore;
using CloudNativeKit.Core.Extensions;
using CloudNativeKit.Persistence.EventStoreDB.Extensions;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Tests.Shared.Helpers;

namespace CloudNativeKit.Persistence.EventStoreDB.IntegrationTests.Fixtures;

public class IntegrationFixture : IAsyncLifetime
{
    private readonly ServiceProvider _provider;

    public IntegrationFixture()
    {
        var builder = Host.CreateApplicationBuilder();

        builder.AddCoreServices();
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
        GC.SuppressFinalize(this);
        return ValueTask.CompletedTask;
    }
}
