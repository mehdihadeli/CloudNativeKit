using CloudNativeKit.Abstractions.Events;
using CloudNativeKit.Abstractions.Messages;

namespace CloudNativeKit.Core.Messages;

public record StreamEventEnvelope<T>(T Data, StreamEventMetadata? Metadata) : IStreamEventEnvelope<T>
    where T : class, IDomainEvent
{
    object IStreamEventEnvelopeBase.Data => Data;
}
