namespace HouseholdAppliances;

public class ElectricStove : Appliance, ICooker
{
    public int BoilingTime { get; set; }
    public int MaximumTemperature { get; set; }

    public ElectricStove(string brand, string model, int boilingTime, int maximumTemperature) : base(brand, model)
    {
        Brand = brand;
        Model = model;
        BoilingTime = boilingTime;
        MaximumTemperature = maximumTemperature;
        IsOn = false;
    }

    public void Cook(string food)
    {
        if (!IsOn)
        {
            throw new ArgumentException($"A propriedade IsOn do {Brand} precisa ser true para utilizar o COOK");
        }
    }

    public void Bake(string food)
    {
        if (!IsOn)
        {
            throw new ArgumentException($"A propriedade IsOn do {Brand} precisa ser true para utilizar o BAKE");
        }
    }

}