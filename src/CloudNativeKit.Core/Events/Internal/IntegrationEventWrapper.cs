using CloudNativeKit.Abstractions.Events;
using CloudNativeKit.Core.Messages;

namespace CloudNativeKit.Core.Events.Internal;

public record IntegrationEventWrapper<TDomainEventType>(TDomainEventType DomainEvent) : IntegrationEvent
    where TDomainEventType : IDomainEvent;
