using Xunit;
using FluentAssertions;
using System;

namespace ShippingCalculator.Test
{
    public class TestShippingCalculator
    {
        [Theory]
        [InlineData(43, 25)]
        [InlineData(51, 20)]
        [InlineData(50, 25)]
        [InlineData(101, 15)]
        [InlineData(100, 20)]
        [InlineData(201, 0)]
        public void TestCalculateShippingSuccess(double orderPrice, int resultExpected)
        {
            var instance = new ShippingCalculator();
            var result = instance.CalculateShipping(orderPrice);
            result.Should().Be(resultExpected);
        }

        [Theory]
        [InlineData(0)]
        [InlineData(-1)]
        public void TestCalculateShippingException(double orderPrice)
        {
            var instance = new ShippingCalculator();
            var act = () => instance.CalculateShipping(orderPrice);
            act.Should().Throw<Exception>().WithMessage("The order price cannot be equal to or less than zero");
        }
    }
}
