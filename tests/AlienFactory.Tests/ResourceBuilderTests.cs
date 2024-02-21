namespace AlienFactory.Tests;

using System.Resources;

public class ResourceBuilderTests
{
    [Fact]
    public void GetResource_ThrowsMissingManifestResourceException_WhenResourceNotFound()
    {
        // Arrange
        const string expected = "Resource Foo_Bar not found";

        // Act
        var method = () => ResourceBuilder.GetResource("Foo", "Bar");

        // Assert
        method.Should()
            .Throw<MissingManifestResourceException>()
            .WithMessage(expected);
    }

    [Fact]
    public void GetResource_ReturnsResource_WhenResourceFound()
    {
        // Arrange
        var vm = new ViewModelBase();
        const string expected = "Alien Factory";

        // Act
        var actual = ResourceBuilder.GetResource("MainWindowViewModel", "Title");

        // Assert
        actual.Should().Be(expected);
    }
}
