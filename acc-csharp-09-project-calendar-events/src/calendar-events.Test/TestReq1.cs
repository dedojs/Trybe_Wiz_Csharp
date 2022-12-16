using Xunit;
using FluentAssertions;
using calendar_events;
using System;

namespace calendar_events.Test;

public class TestReq1
{
    [Theory(DisplayName = "Deve cadastrar um evento com o construtor completo")]
    [InlineData("Teste", "11/11/2022", "Teste do teste do construtor")]
    public void TestEventFullConstructor(string title, string date, string description)
    {
        var ExemploEvento = new Event(title, date, description);
        ExemploEvento.Title.Should().Be(title);
        ExemploEvento.EventDate.Should().Be(DateTime.Parse(date, Event.Culture));
        ExemploEvento.Description.Should().Be(description);
    }

    [Theory(DisplayName = "Deve cadastrar um evento com o construtor sem descrição")]
    [InlineData("Teste", "11/11/2022")]
    public void TestEventHalfConstructor(string title, string date)
    {
        var ExemploEvento = new Event(title, date);
        ExemploEvento.Title.Should().Be(title);
        ExemploEvento.EventDate.Should().Be(DateTime.Parse(date, Event.Culture));
    }

    [Theory(DisplayName = "Deve atrasar a data de um evento corretamente")]
    [InlineData("Teste", "11/11/2022", 10, "21/11/2022")]
    public void TestEventDelayDate(string title, string date, int days, string expected)
    {
        var ExemploEvento = new Event(title, date);
        ExemploEvento.EventDate.Should().Be(DateTime.Parse(date, Event.Culture));
        ExemploEvento.DelayDate(days);
        ExemploEvento.EventDate.Should().Be(DateTime.Parse(expected, Event.Culture));
    }

    [Theory(DisplayName = "Deve imprimir um evento corretamente")]
    [InlineData("Festa do pudim", "2022-05-05", "Uma festa onde cada um leva seu pudim!", "normal", "Evento = Festa do pudim\nDate = 05/05/2022\n")]

    [InlineData("Teste", "11/11/2022", "Teste do teste do construtor", "detailed", "Evento = Teste\nDate = 11/11/2022\nDescription = Teste do teste do construtor")]
    public void TestPrintEvent(string title, string date, string description, string format, string expected)
    {
        var ExemploEvento = new Event(title, date, description);
        ExemploEvento.PrintEvent(format).Should().Be(expected); 
    }
    
    
}