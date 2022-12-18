using System.Security.Principal;

namespace Geometry.Test;

public class CubeTest
{
    [InlineData(2)]
    [InlineData(3)]
    [InlineData(4)]
    [Theory]
    public void TestCube(double side)
    {
        var instance = new Cube(side);
        instance.Should().NotBeNull();
        instance.Side.Should().Be(side);
        instance.FaceA.Area.Should().Be(side * side);
        instance.FaceB.Area.Should().Be(side * side);
        instance.FaceC.Area.Should().Be(side * side);
        instance.Volume.Should().Be(side * side * side);
    }

    [Theory]
    [InlineData(-2)]
    [InlineData(0)]
    public void TestCubeException(double side)
    {
        Action act = () => new Cube(side);
        act.Should().Throw<ArgumentException>();
        act.Should().Throw<ArgumentException>().WithMessage("All sides must be greater than zero");
    }
}