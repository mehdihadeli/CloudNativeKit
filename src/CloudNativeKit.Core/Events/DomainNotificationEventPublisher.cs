namespace CloudNativeKit.Core.Events;

using CloudNativeKit.Abstractions.Events;
using CloudNativeKit.Abstractions.Messages.MessagePersistence;
using CloudNativeKit.Core.Extensions;

public class DomainNotificationEventPublisher(IMessagePersistenceService messagePersistenceService)
    : IDomainNotificationEventPublisher
{
    public Task PublishAsync<T>(
        IDomainNotificationEvent<T> domainNotificationEvent,
        CancellationToken cancellationToken = default
    )
        where T : class, IDomainEvent
    {
        domainNotificationEvent.NotBeNull();
        return messagePersistenceService.AddNotificationAsync(domainNotificationEvent, cancellationToken);
    }

    public async Task PublishAsync<T>(
        IEnumerable<IDomainNotificationEvent<T>> domainNotificationEvents,
        CancellationToken cancellationToken = default
    )
        where T : class, IDomainEvent
    {
        foreach (var domainNotificationEvent in domainNotificationEvents)
        {
            await messagePersistenceService.AddNotificationAsync(domainNotificationEvent, cancellationToken);
        }
    }
}
