using CloudNativeKit.Abstractions.Events;

namespace CloudNativeKit.Abstractions.Messages;

public interface IStreamEventEnvelope<out T> : IStreamEventEnvelopeBase
    where T : class, IDomainEvent
{
    new T Data { get; }
}
