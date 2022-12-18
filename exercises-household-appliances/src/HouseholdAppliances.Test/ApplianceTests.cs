namespace HouseholdAppliances.Test;

public class ApplianceTests
{
    public static TheoryData<object, object> PolymorphismData => new TheoryData<object, object>
    {
        {
            new Microwave("Samsung", "MW-01", 5, 100),
            new ElectricStove("Electrolux", "ST-02", 10, 200)
        },
    };

    [Theory]
    [InlineData("Samsung", "ST-01", 5, 100, false)]
    [InlineData("Electrolux", "ST-02", 10, 200, false)]
    public void TestMicrowave(string brand, string model, int boilingTime, int maximumTemperature, bool initialIsOn)
    {
        var instance = new Microwave(brand, model, boilingTime, maximumTemperature);
        instance.Should().NotBeNull();
        instance.IsOn.Should().Be(initialIsOn);
        instance.Brand.Should().Be(brand);
        instance.Model.Should().Be(model);
        instance.BoilingTime.Should().Be(boilingTime);
        instance.MaximumTemperature.Should().Be(maximumTemperature);

        Action actCook = () => instance.Cook("comida teste");
        actCook.Should().Throw<ArgumentException>();
        actCook.Should().Throw<ArgumentException>().WithMessage($"A propriedade IsOn do {instance.Brand} precisa ser true para utilizar o COOK");

        Action actHeat = () => instance.Heat("comida teste");
        actHeat.Should().Throw<ArgumentException>();
        actHeat.Should().Throw<ArgumentException>().WithMessage($"A propriedade IsOn do {instance.Brand} precisa ser true para utilizar o HEAT");

        instance.SwitchPower();
        instance.IsOn.Should().BeTrue();
        
    }

    [Theory]
    [InlineData("Samsung", "MW-01", 5, 100, false)]
    [InlineData("Electrolux", "MW-02", 10, 200, false)]
    public void TestElectricStove(string brand, string model, int boilingTime, int maximumTemperature, bool initialIsOn)
    {
        var instance = new ElectricStove(brand, model, boilingTime, maximumTemperature);
        instance.Should().NotBeNull();
        instance.IsOn.Should().Be(initialIsOn);
        instance.Brand.Should().Be(brand);
        instance.Model.Should().Be(model);
        instance.BoilingTime.Should().Be(boilingTime);
        instance.MaximumTemperature.Should().Be(maximumTemperature);

        Action actCook = () => instance.Cook("comida teste");
        actCook.Should().Throw<ArgumentException>();
        actCook.Should().Throw<ArgumentException>().WithMessage($"A propriedade IsOn do {instance.Brand} precisa ser true para utilizar o COOK");

        Action actBake = () => instance.Bake("comida teste");
        actBake.Should().Throw<ArgumentException>();
        actBake.Should().Throw<ArgumentException>().WithMessage($"A propriedade IsOn do {instance.Brand} precisa ser true para utilizar o BAKE");

        instance.SwitchPower();
        instance.IsOn.Should().BeTrue();
    }

    [Theory]
    [MemberData(nameof(PolymorphismData))]
    public void TestPolymorphism(object microwave, object electricStove)
    {
        microwave.Should().BeOfType<Microwave>();
        microwave.Should().BeAssignableTo<Appliance>();
        microwave.Should().BeAssignableTo<ICooker>();

        electricStove.Should().BeOfType<ElectricStove>();
        electricStove.Should().BeAssignableTo<Appliance>();
        electricStove.Should().BeAssignableTo<ICooker>();

    }
}