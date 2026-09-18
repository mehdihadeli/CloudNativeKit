using CloudNativeKit.Abstractions.Events;

namespace CloudNativeKit.Core.Events;

public class NullIDomainEventContext : IDomainEventContext
{
    public IReadOnlyList<IDomainEvent> DequeueUncommittedDomainEvents()
    {
        return new List<IDomainEvent>();
    }
}
