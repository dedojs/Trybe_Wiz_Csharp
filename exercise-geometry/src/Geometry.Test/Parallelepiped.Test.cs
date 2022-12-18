namespace Geometry.Test;

public class ParallelepipedTest
{
    [InlineData(2, 3, 4)]
    [InlineData(3, 4, 5)]
    [Theory]
    public void TestParallelepiped(double height, double width, double depth)
    {
        var instance = new Parallelepiped(height, width, depth);
        instance.Height.Should().Be(height);
        instance.Width.Should().Be(width);
        instance.Depth.Should().Be(depth);
        instance.Volume.Should().Be(height * width * depth);
        instance.FaceA.Area.Should().Be(height * width);
        instance.FaceB.Area.Should().Be(height * depth);
        instance.FaceC.Area.Should().Be(width * depth);
        instance.SurfaceArea.Should().Be(2 * (instance.FaceA.Area + instance.FaceB.Area + instance.FaceC.Area));
    }

    [Theory]
    [InlineData(0, 3, 4)]
    [InlineData(2, 0, 4)]
    [InlineData(2, 2, 0)]
    [InlineData(-1, 3, 4)]
    [InlineData(2, -1, 4)]
    [InlineData(2, 3, -1)]
    public void TestParallelepipedException(double height, double width, double depth)
    {
        Action act = () => new Parallelepiped(height, width, depth);
        act.Should().Throw<ArgumentException>();
        act.Should().Throw<ArgumentException>().WithMessage("All sides must be greater than zero");
    }
}