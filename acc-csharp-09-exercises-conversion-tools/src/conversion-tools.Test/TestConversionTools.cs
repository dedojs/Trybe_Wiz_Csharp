using Xunit;
using FluentAssertions;
using conversion_tools;
using System;

namespace conversion_tools.Test;

public class TestFirstRequirement{
    [Theory]
    [InlineData("1", 1)]
    public void TestConvertStrToInt(string entry, int expected)
    {
        ConversionTools instance = new();

        instance.strVariable = entry;
        instance.ConvertStrToInt();
        var typeCheck = instance.intVariable is int;
        typeCheck.Should().Be(true);
        instance.intVariable.Should().Be(expected);

    }
}

public class TestSecondRequirement{
    [Theory]
    [InlineData("1.0", 1.0)]
    public void TestConvertStrToDouble(string entry, double expected)
    {
        ConversionTools instance = new();

        instance.strVariable = entry;
        instance.ConvertStrToDouble();
        var typeCheck = instance.doubleVariable is double;
        typeCheck.Should().Be(true);
        instance.doubleVariable.Should().Be(expected);
    }
}

public class TestThirdRequirement{
    [Theory]
    [InlineData(1, "1")]
    public void TestConvertIntToStr(int entry, string expected)
    {
        ConversionTools instance = new();
        instance.intVariable = entry;
        instance.ConvertIntToStr();
        var typeCheck = instance.strVariable is string;
        typeCheck.Should().Be(true);
        instance.strVariable.Should().Be(expected);
    }
}

public class TestFourthRequirement{
    [Theory]
    [InlineData(4.1, "4.1")]
    public void TestConvertDoubleToStr(double entry, string expected)
    {
        ConversionTools instance = new();
        instance.doubleVariable = entry;
        instance.ConvertDoubleToStr();
        var typeCheck = instance.strVariable is string;
        typeCheck.Should().Be(true);
        instance.strVariable.Should().Be(expected);
    }
}
