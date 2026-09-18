using System.Diagnostics.CodeAnalysis;
using CloudNativeKit.Abstractions.Domain.EventSourcing;
using CloudNativeKit.Core.Extensions;

namespace CloudNativeKit.Core.Persistence.EventStore;

public class StreamName([NotNull] string? value)
{
    public string Value { get; } = value.NotBeNull();

    public static StreamName For<T>(string id) => new($"{typeof(T).Name}-{id.NotBeNullOrWhiteSpace()}");

    public static StreamName For<TAggregate, TId>(TId aggregateId)
        where TAggregate : IEventSourcedAggregate<TId>
    {
        aggregateId.NotBeNull();
        var id = aggregateId.ToString().NotBeNullOrWhiteSpace();
        return For<TAggregate>(id);
    }

    public static implicit operator string(StreamName streamName) => streamName.Value;

    public override string ToString() => Value;
}
