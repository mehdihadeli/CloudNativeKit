using CloudNativeKit.Abstractions.Events;
using CloudNativeKit.Abstractions.Messages;

namespace CloudNativeKit.Abstractions.Persistence.EventStore.Projections;

public interface IReadProjectionPublisher
{
    Task PublishAsync(IStreamEventEnvelopeBase streamEvent, CancellationToken cancellationToken = default);

    Task PublishAsync<T>(IStreamEventEnvelope<T> streamEvent, CancellationToken cancellationToken = default)
        where T : class, IDomainEvent;
}
