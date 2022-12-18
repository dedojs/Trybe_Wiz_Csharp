namespace HouseholdAppliances;

public class Microwave : Appliance, ICooker
{
    public Microwave(string brand, string model, int boilingTime, int maximumTemperature) : base (brand, model)
    {
        Brand = brand;
        Model = model;
        BoilingTime = boilingTime;
        MaximumTemperature = maximumTemperature;
        IsOn = false;
    }

    public int BoilingTime { get; set; }
    public int MaximumTemperature { get; set; }

    public void Cook(string food)
    {
        if (!IsOn)
        {
            throw new ArgumentException($"A propriedade IsOn do {Brand} precisa ser true para utilizar o COOK");
        }

        Console.WriteLine($"O Microondas {Brand}, modelo {Model} esta cozinhando a comida:{food}");
    }

    public void Heat(string food)
    {
        if (!IsOn)
        {
            throw new ArgumentException($"A propriedade IsOn do {Brand} precisa ser true para utilizar o HEAT");
        }
        Console.WriteLine($"O Microondas {Brand}, modelo {Model} esta aquecendo a comida:{food}");
    }
}

   