using CloudNativeKit.Abstractions.Commands;
using CloudNativeKit.Core.Types;

namespace CloudNativeKit.Core.Commands;

public abstract record InternalCommand : IInternalCommand
{
    public Guid InternalCommandId { get; protected set; } = Guid.NewGuid();

    public DateTime OccurredOn { get; protected set; } = DateTime.Now;

    public string Type
    {
        get { return TypeMapper.AddFullTypeName(GetType()); }
    }
}
