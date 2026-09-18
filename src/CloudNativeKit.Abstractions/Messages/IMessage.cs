namespace CloudNativeKit.Abstractions.Messages;

public interface IMessage
{
    Guid MessageId { get; }
    DateTime Created { get; }
}
