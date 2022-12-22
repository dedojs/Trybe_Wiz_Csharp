using DateNow.Controllers;
using Xunit;
using FluentAssertions;
using Microsoft.AspNetCore.Mvc;

namespace DateNow.Test;

public class TestCurrentYearController
{
    [Theory]
    [InlineData(2022, true)]
    public void TestCurrentYearSuccess(int year, bool resultExpected)
    {
        var yearTest = new CurrentYearController().Get();
        bool result = yearTest == year;

        result.Should().Be(resultExpected); 

    }
}
