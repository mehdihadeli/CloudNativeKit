using CloudNativeKit.Abstractions.Events;

namespace CloudNativeKit.Core.Events.Internal;

public abstract record DomainNotificationEvent<TDomainEvent>(TDomainEvent DomainEvent)
    : Event,
        IDomainNotificationEvent<TDomainEvent>
    where TDomainEvent : IDomainEvent;
