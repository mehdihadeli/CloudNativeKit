using CloudNativeKit.Core.Persistence.EventStore.Extensions;
using CloudNativeKit.Persistence.EventStoreDB.Extensions;
using EventStore.Client;
using FluentAssertions;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Options;
using Tests.Shared.Helpers;

namespace CloudNativeKit.Persistence.EventStoreDB.IntegrationTests;

public class DependencyInjectionsTests
{
    private readonly ServiceProvider _provider;

    public DependencyInjectionsTests()
    {
        var builder = Host.CreateApplicationBuilder();

        builder.AddEventStoreDb();

        _provider = builder.Services.BuildServiceProvider();
    }

    [Fact]
    public void should_resolve_event_store_db()
    {
        var eventStoreClient = _provider.GetService<EventStoreClient>();
        eventStoreClient.Should().NotBeNull();
    }

    [Fact]
    public void should_resolve_event_store_db_options()
    {
        var options = _provider.GetService<IOptions<EventStoreDbOptions>>();
        options.Should().NotBeNull();
        options!.Value.GrpcConnectionString.Should().Be("esdb://localhost:2113?tls=false");
    }
}
