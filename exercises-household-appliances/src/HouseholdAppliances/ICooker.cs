namespace HouseholdAppliances;

public interface ICooker
{
    public int BoilingTime { get; set; }
    public int MaximumTemperature { get; set; }

    public void Cook(string food);
}
