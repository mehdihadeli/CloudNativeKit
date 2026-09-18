using CloudNativeKit.Abstractions.Messages;

namespace CloudNativeKit.Abstractions.Events;

public interface IIntegrationEventMapper
{
    IIntegrationEvent? MapToIntegrationEvent(IDomainEvent domainEvent);
}
