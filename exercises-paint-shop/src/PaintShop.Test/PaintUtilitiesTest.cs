namespace PaintShop.Test;

public class PaintUtilitiesTest
{
    public static TheoryData<double, Wall, Room, int> ValidOverloadData =>
        new TheoryData<double, Wall, Room, int>
        {
            {
                1000,
                new Wall(100, 10),
                new Room(new Wall(100, 5), new Wall(100, 5)),
                5
            },
        };

    public static TheoryData<double, Wall, Room, int, decimal> ValidOverloadDataWithExpectedPrice =>
        new TheoryData<double, Wall, Room, int, decimal>
        {
            {
                1000,
                new Wall(100, 10),
                new Room(new Wall(100, 5), new Wall(100, 5)),
                300,
                1500
            },
        };

    [Theory]
    [InlineData(20, 10, 200, 40, 20, 800)]
    public void TestPaintUtilitiesInitialValues(
        int bucketSize,
        int sqMtPerLiter,
        int sqMtPerBucket,
        int newBucketSize,
        int newSqMtPerLiter,
        int newSqMtPerBucket)
    {
        PaintUtilities.BucketSizeLiters.Should().Be(bucketSize);
        PaintUtilities.SquareMetersPerLiter.Should().Be(sqMtPerLiter);
        PaintUtilities.SquareMetersPerBucket.Should().Be(sqMtPerBucket);

        PaintUtilities.BucketSizeLiters = newBucketSize;
        PaintUtilities.BucketSizeLiters.Should().Be(newBucketSize);

        PaintUtilities.SquareMetersPerLiter = newSqMtPerLiter;
        PaintUtilities.SquareMetersPerLiter.Should().Be(newSqMtPerLiter);

        PaintUtilities.SquareMetersPerBucket.Should().Be(newSqMtPerBucket);

        PaintUtilities.BucketSizeLiters = bucketSize;
        PaintUtilities.SquareMetersPerLiter = sqMtPerLiter;
    }

    [Theory]
    [MemberData(nameof(ValidOverloadData))]
    public void TestGetNeededPaintBucketsCalculation(double area, Wall wall, Room room, int expectedBuckets)
    {
        var resultArea = PaintUtilities.GetNeededPaintBuckets(area);
        resultArea.Should().Be(expectedBuckets);

        var resultWall = PaintUtilities.GetNeededPaintBuckets(wall);
        resultWall.Should().Be(expectedBuckets);

        var resultRoom = PaintUtilities.GetNeededPaintBuckets(room);
        resultRoom.Should().Be(expectedBuckets);
    }

    [Theory]
    [MemberData(nameof(ValidOverloadDataWithExpectedPrice))]
    public void TestCalculateCostCalculation(double area, Wall wall, Room room, decimal price, decimal expectedPrice)
    {
        var resultArea = PaintUtilities.CalculateCost(price, area);
        resultArea.Should().Be(expectedPrice);

        var resultWall = PaintUtilities.CalculateCost(price, wall);
        resultWall.Should().Be(expectedPrice);

        var resultRoom = PaintUtilities.CalculateCost(price, room);
        resultRoom.Should().Be(expectedPrice);
    }
}
