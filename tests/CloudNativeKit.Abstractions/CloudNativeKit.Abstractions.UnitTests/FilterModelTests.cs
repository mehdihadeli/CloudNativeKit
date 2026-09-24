using CloudNativeKit.Abstractions;

namespace CloudNativeKit.Abstractions.UnitTests;

public class FilterModelTests
{
    [Fact]
    public void should_create_filter_model_with_expected_values()
    {
        var model = new FilterModel("Name", "eq", "CloudNativeKit");

        Assert.Equal("Name", model.FieldName);
        Assert.Equal("eq", model.Comparision);
        Assert.Equal("CloudNativeKit", model.FieldValue);
    }
}
