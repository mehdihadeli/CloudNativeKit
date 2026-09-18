using CloudNativeKit.Abstractions.Domain;
using CloudNativeKit.Abstractions.Domain.EventSourcing;
using CloudNativeKit.Abstractions.Events;
using CloudNativeKit.Abstractions.Persistence.EventStore.Projections;

namespace CloudNativeKit.Abstractions.Persistence.EventStore;

public interface IHaveEventSourcingAggregate
    : IHaveAggregateStateProjection,
        IAggregateBase,
        IHaveEventSourcedAggregateVersion
{
    /// <summary>
    ///     Loads the current state of the aggregate from a list of events.
    /// </summary>
    /// <param name="history">Domain events from the aggregate stream.</param>
    void LoadFromHistory(IEnumerable<IDomainEvent> history);
}
