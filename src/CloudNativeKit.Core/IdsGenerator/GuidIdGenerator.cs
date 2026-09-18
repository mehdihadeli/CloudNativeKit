using CloudNativeKit.Abstractions.Core;

namespace CloudNativeKit.Core.IdsGenerator;

public class GuidIdGenerator : IIdGenerator<Guid>
{
    public Guid New()
    {
        return Guid.NewGuid();
    }
}
