using CloudNativeKit.Abstractions.Events;

namespace CloudNativeKit.Abstractions.Commands;

public interface IInternalCommandMapper
{
    IReadOnlyList<IInternalCommand?>? MapToInternalCommands(IReadOnlyList<IDomainEvent> domainEvents);
    IInternalCommand? MapToInternalCommand(IDomainEvent domainEvent);
}
