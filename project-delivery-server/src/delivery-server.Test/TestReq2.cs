using Xunit;
using FluentAssertions;
using delivery_server;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Threading.Tasks;

namespace delivery_server.Test;

public class TestReq2
{
    
    public static IEnumerable<object[]> ItemTestData()
    {
        yield return new object[] {new Item("arroz", 32.0, 2000), 32};
        yield return new object[] {new Item("feijão", 12.0, 2000), 12};
        yield return new object[] {new Item("carne", 10.4, 2000), 2};
        yield return new object[] {new Item("macarrão", 1.5, 2000), 1};
        yield return new object[] {new Item("queijo", 9.3, 2000), 94};
    }

    public static IEnumerable<object[]> OrderTestData()
    {
        yield return new object[] { new Order(new Item("arroz", 32.0, 2000), 1)};
        yield return new object[] { new Order(new Item("feijão", 32.0, 1000), 2)};
        yield return new object[] { new Order(new Item("carne", 32.0, 500), 3)};
        yield return new object[] { new Order(new Item("macarrão", 32.0, 5000), 1)};
        yield return new object[] { new Order(new Item("batata", 32.0, 3000), 3)};
    }

    [Theory(DisplayName = "Deve construir uma Order corretamente")]
    [MemberData(nameof(ItemTestData))]
    public void TestCreateOrder(Item itemEntry, int quantityEntry)
    {
        var order = new Order(itemEntry, quantityEntry);
        order.Item.Should().Be(itemEntry);
        order.Quantity.Should().Be(quantityEntry);
        order.OrderPrice.Should().Be(itemEntry.Price * quantityEntry);
        order.IsReady.Should().BeFalse();
        order.IsSend.Should().BeFalse();
    }

    [Theory(DisplayName = "Deve alterar o atributo IsReady após o tempo determinado")]
    [MemberData(nameof(OrderTestData))]
    public async void TestProcessOrder(Order orderEntry)
    {
        Stopwatch timer = new Stopwatch();
        timer.Start();
        await Task.Run(() => orderEntry.Process());
        timer.Stop();
        long timeDelay = timer.ElapsedMilliseconds;
        orderEntry.IsReady.Should().BeTrue();
        timeDelay.Should().BeGreaterThanOrEqualTo(orderEntry.Delay);
    }
    
}