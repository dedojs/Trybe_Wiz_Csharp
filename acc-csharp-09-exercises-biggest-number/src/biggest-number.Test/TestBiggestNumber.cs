using Xunit;
using FluentAssertions;
using System;

namespace BiggestNumber.Test;

public class TestBiggestNumber
{
    [Theory(DisplayName = "Encontrar o maior número")]
    [InlineData(2, 4, 8, 8)]
    // [InlineData(2, 10, 8, 10)]
    // [InlineData(20, 4, 8, 20)]
    public void TestIdentifyBiggestNumberSucess(int first, int second, int third, int expectedNumber)
    {
        var result = BiggestNumber.IdentifyBiggestNumber(first, second, third);
        result.Should().Be(expectedNumber);
    }
}