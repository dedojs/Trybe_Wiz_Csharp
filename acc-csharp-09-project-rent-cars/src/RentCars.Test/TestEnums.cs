using RentCars.Types;

namespace RentCars.Test;

public class TestEnums
{
    [Theory]
    [InlineData(1, "Chamber")]
    [InlineData(2, "Disc")]
    [InlineData(3, "Drum")]
    public void BreakeTypeShouldHaveCorrectValues(int valueEntry, string expected)
    {
        var brakeType = (BrakeType)valueEntry;
        Assert.Equal(expected, brakeType.ToString()); 
    }

    [Theory]
    [InlineData(0, "FrontWheelDrive")]
    [InlineData(1, "RearWheelDrive")]
    [InlineData(2, "AllWheelDrive")]
    public void TractionTypeShouldHaveCorrectValues(int valueEntry, string expected)
    {
        var tractionType = (TractionType)valueEntry;
        Assert.Equal(expected, tractionType.ToString()); 
    }

    [Theory]
    [InlineData(10, "Alcohol")]
    [InlineData(20, "Gasoline")]
    [InlineData(30, "Flex")]
    [InlineData(40, "Diesel")]
    [InlineData(50, "Electric")]
    [InlineData(60, "Hybrid")]
    public void FuelTypeShouldHaveCorrectValues(int valueEntry, string expected)
    {
        var fuelType = (FuelType)valueEntry;
        Assert.Equal(expected, fuelType.ToString()); 
    }

    [Theory]
    [InlineData(0, "Confirmed")]
    [InlineData(1, "Finished")]
    public void RentStatusShouldHaveCorrectValues(int valueEntry, string expected)
    {
        var rentStatus = (RentStatus)valueEntry;
        Assert.Equal(expected, rentStatus.ToString());
    }

    [Fact]
    public void RentStatusFinishedShouldBeTheSameValueAsCancelled()
    {
        Assert.Equal(RentStatus.Finished, RentStatus.Cancelled);
    }
}
