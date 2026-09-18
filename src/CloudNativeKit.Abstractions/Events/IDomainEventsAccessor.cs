namespace CloudNativeKit.Abstractions.Events;

public interface IDomainEventsAccessor
{
    IReadOnlyList<IDomainEvent> DequeueUncommittedDomainEvents();
}
