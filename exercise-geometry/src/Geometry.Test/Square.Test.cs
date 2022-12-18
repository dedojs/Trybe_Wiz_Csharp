namespace Geometry.Test;

public class SquareTest
{
    [InlineData(2)]
    [InlineData(3)]
    [InlineData(4)]
    [Theory]
    public void TestSquare(double side)
    {
        var instance = new Square(side);
        instance.Width = side;
        instance.Height = side;
        instance.Area.Should().Be(side * side);
    }

    [InlineData(-1)]
    [InlineData(0)]
    [Theory]
    public void TestSquareException(double side)
    {
        var act = () => new Square(side);
        act.Should().Throw<ArgumentException>();
    }
}