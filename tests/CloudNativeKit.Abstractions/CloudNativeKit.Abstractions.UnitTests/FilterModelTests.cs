using CloudNativeKit.Abstractions;

namespace CloudNativeKit.Abstractions.UnitTests;

public class FilterModelTests
{
    [Fact]
    public void constructor_should_set_filter_model_properties()
    {
        var filter = new FilterModel("Name", "Equals", "CloudNativeKit");

        filter.FieldName.ShouldBe("Name");
        filter.Comparision.ShouldBe("Equals");
        filter.FieldValue.ShouldBe("CloudNativeKit");
    }
}
