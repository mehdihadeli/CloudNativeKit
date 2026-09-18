using Marten.Schema.Identity;

namespace CloudNativeKit.Persistence.Marten;

public static class MartenIdGenerator
{
    public static Guid New() => CombGuidIdGeneration.NewGuid();
}
