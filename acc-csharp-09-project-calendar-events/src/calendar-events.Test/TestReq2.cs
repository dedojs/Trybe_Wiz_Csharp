using Xunit;
using FluentAssertions;
using calendar_events;
using System;

namespace calendar_events.Test;

public class TestReq2
{
    [Theory(DisplayName = "Deve procurar um evento por titulo")]
    [InlineData("Teste", "11/11/2022", "Descrição", 0)]
    public void TestListSearchByTitle(string title, string date, string description,int expected)
    {
        var testeEvento = new Event(title, date, description);
        var list = new EventList();
        list.Add(testeEvento);
        list.SearchByTitle(title).Should().Be(expected);
    }

    [Theory(DisplayName = "Deve procurar um evento por data")]
    [InlineData("Teste", "11/11/2022", "Descrição", 0)]
    public void TestListSearchByDate(string title, string date, string description, int expected)
    {
        var testeEvento = new Event(title, date, description);
        var list = new EventList();
        list.Add(testeEvento);
        list.SearchByDate(date).Should().Be(expected);
    }

    
}