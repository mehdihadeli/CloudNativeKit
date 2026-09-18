namespace CloudNativeKit.Abstractions.Events;

public interface IDomainNotificationEventMapper
{
    IDomainNotificationEvent<IDomainEvent>? MapToDomainNotificationEvent(IDomainEvent domainEvent);
}
