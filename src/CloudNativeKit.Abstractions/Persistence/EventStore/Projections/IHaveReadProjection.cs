using CloudNativeKit.Abstractions.Events;
using CloudNativeKit.Abstractions.Messages;

namespace CloudNativeKit.Abstractions.Persistence.EventStore.Projections;

public interface IHaveReadProjection
{
    Task ProjectAsync<T>(IStreamEventEnvelope<T> iStreamEvent, CancellationToken cancellationToken = default)
        where T : class, IDomainEvent;
}
