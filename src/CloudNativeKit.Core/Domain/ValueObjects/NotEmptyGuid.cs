using CloudNativeKit.Core.Extensions;

namespace CloudNativeKit.Core.Domain.ValueObjects;

public record NotEmptyGuid
{
    protected NotEmptyGuid(Guid value) => Value = value.NotBeEmpty();

    public Guid Value { get; }
}
