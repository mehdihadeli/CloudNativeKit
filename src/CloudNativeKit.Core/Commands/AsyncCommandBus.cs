using CloudNativeKit.Abstractions.Commands;
using CloudNativeKit.Abstractions.Messages;
using CloudNativeKit.Abstractions.Messages.MessagePersistence;
using CloudNativeKit.Core.Messages;

namespace CloudNativeKit.Core.Commands;

public class AsyncCommandBus(IServiceProvider serviceProvider, IMessageMetadataAccessor messageMetadataAccessor)
    : IAsyncCommandBus
{
    public Task SendExternalAsync<TCommand>(TCommand command, CancellationToken cancellationToken = default)
        where TCommand : class, IAsyncCommand
    {
        var correlationId = messageMetadataAccessor.GetCorrelationId();
        var cautionId = command.MessageId;
        var eventEnvelope = MessageEnvelopeFactory.From(command, correlationId, cautionId);

        var messagePersistenceService = serviceProvider.GetRequiredService<IMessagePersistenceService>();
        return messagePersistenceService.AddPublishMessageAsync(eventEnvelope, cancellationToken);
    }
}
