using CloudNativeKit.Core.Extensions;

namespace CloudNativeKit.Core.Domain.ValueObjects;

public record NotNegativeOrZero
{
    public NotNegativeOrZero(int value) => Value = value.NotBeNegativeOrZero();

    public int Value { get; }
}
