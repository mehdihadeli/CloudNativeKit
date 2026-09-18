using CloudNativeKit.Abstractions.Commands;
using CloudNativeKit.Abstractions.Events;
using CloudNativeKit.Abstractions.Messages;
using CloudNativeKit.Abstractions.Messages.MessagePersistence;

namespace CloudNativeKit.Core.Messages;

public class NullMessagePersistenceService : IMessagePersistenceService
{
    public Task AddPublishMessageAsync(
        IMessageEnvelopeBase messageEnvelope,
        CancellationToken cancellationToken = default
    )
    {
        return Task.CompletedTask;
    }

    public Task AddReceivedMessageAsync<TMessage>(
        IMessageEnvelopeBase messageEnvelope,
        Func<IMessageEnvelopeBase, Task> dispatchAction,
        CancellationToken cancellationToken = default
    )
    {
        return dispatchAction(messageEnvelope);
    }

    public Task AddInternalMessageAsync<TInternalCommand>(
        TInternalCommand internalCommand,
        CancellationToken cancellationToken = default
    )
        where TInternalCommand : IInternalCommand
    {
        return Task.CompletedTask;
    }

    public Task AddNotificationAsync<TDomainNotification>(
        TDomainNotification notification,
        CancellationToken cancellationToken = default
    )
        where TDomainNotification : IDomainNotificationEvent<IDomainEvent>
    {
        return Task.CompletedTask;
    }
}
