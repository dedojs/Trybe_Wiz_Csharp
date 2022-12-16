using Xunit;
using FluentAssertions;
using delivery_server;
using System;

namespace delivery_server.Test;

public class TestReq1
{
    [Theory(DisplayName = "Deve construir um Item corretamente")]
    [InlineData("Feijao", 7.98, 90)]

    public void TestCreateItem(string nameEntry, double priceEntry, int timeEntry)
    {
        var produto = new Item(nameEntry, priceEntry, timeEntry);

        produto.Name.Should().Be(nameEntry);
        produto.Price.Should().Be(priceEntry);
        produto.TimeToPrepare.Should().Be(timeEntry);
    }
}