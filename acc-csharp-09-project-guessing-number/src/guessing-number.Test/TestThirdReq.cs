using Xunit;
using System.IO;
using System;
using Moq;
using guessing_number;
using FluentAssertions;

namespace guessing_number.Test;

[Collection("Sequential")]
public class TestThirdReq
{
    [Theory(DisplayName = "Deve receber a executar o fluxo completo do programa")]
    [InlineData(new object[] {new string[]{"10"}, 10})]
    public void TestFullFlow(string[] entrys, int mockValue)
    {
        GuessNumber game = new();

        foreach(string entry in entrys)
        {
            var stringReader = new StringReader(entry);
            Console.SetIn(stringReader);
        }

        game.randomValue = mockValue;

        for(var i = 0; i < entrys.Length; i++)
        {
            game.ChooseNumber();
            game.AnalyzePlay();
        }

        game.userValue.Should().Be(mockValue);

    }
}