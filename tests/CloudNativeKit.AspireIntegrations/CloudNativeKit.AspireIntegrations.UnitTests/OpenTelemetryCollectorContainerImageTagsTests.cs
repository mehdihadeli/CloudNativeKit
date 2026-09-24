using CloudNativeKit.AspireIntegrations.OpenTelemetryCollector;

namespace CloudNativeKit.AspireIntegrations.UnitTests;

public class OpenTelemetryCollectorContainerImageTagsTests
{
    [Fact]
    public void should_expose_expected_container_image_values()
    {
        Assert.Equal("docker.io", OpenTelemetryCollectorContainerImageTags.Registry);
        Assert.Equal("otel/opentelemetry-collector-contrib", OpenTelemetryCollectorContainerImageTags.Image);
        Assert.Equal("latest", OpenTelemetryCollectorContainerImageTags.Tag);
    }
}
