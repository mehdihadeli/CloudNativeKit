using CloudNativeKit.Abstractions.Events;

namespace CloudNativeKit.Core.Events.Internal;

public abstract record DomainNotificationEventWrapper<TDomainEventType>(TDomainEventType DomainEvent)
    : DomainNotificationEvent<TDomainEventType>(DomainEvent)
    where TDomainEventType : IDomainEvent;
