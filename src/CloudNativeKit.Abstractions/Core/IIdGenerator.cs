namespace CloudNativeKit.Abstractions.Core;

public interface IIdGenerator<out TId>
{
    TId New();
}
