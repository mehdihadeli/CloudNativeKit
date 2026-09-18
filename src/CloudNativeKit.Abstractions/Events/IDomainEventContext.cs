namespace CloudNativeKit.Abstractions.Events;

public interface IDomainEventContext
{
    IReadOnlyList<IDomainEvent> DequeueUncommittedDomainEvents();
}
