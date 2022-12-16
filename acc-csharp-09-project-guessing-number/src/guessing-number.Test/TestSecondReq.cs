using Xunit;
using System.IO;
using System;
using Moq;
using guessing_number;
using FluentAssertions;

namespace guessing_number.Test;

[Collection("Sequential")]
public class TestSecondReq
{
    [Theory(DisplayName = "Deve escolher randomicamente um número entre -100 e 100!")]
    [InlineData(-100, 100)]
    public void TestRandomlyChooseANumber(int MinimumRange, int MaximumRange)
    {
        GuessNumber game = new();

        game.RandomNumber();

        var randomChoice = game.randomValue;

        randomChoice.Should().BeGreaterThanOrEqualTo(MinimumRange);
        randomChoice.Should().BeLessThanOrEqualTo(MaximumRange);
    }

    [Theory(DisplayName = "Deve comparar a entrada do usuário em um caso MENOR")]
    [InlineData(50, 0)]
    public void TestProgramComparisonValuesLess(int mockValue, int entry)
    {
        GuessNumber game = new();

        StringWriter stringWriter = new();
        Console.SetOut(stringWriter);

        game.randomValue = mockValue;
        game.userValue = entry;
        game.AnalyzePlay();

        string msg = stringWriter.ToString().Trim();
        msg.Should().Be("Tente um número MAIOR");

    }
    [Theory(DisplayName = "Deve comparar a entrada do usuário em um caso MAIOR")]
    [InlineData(50, 60)]
    public void TestProgramComparisonValuesBigger(int mockValue, int entry)
    {
        GuessNumber game = new();

        StringWriter stringWriter = new();
        Console.SetOut(stringWriter);

        game.randomValue = mockValue;
        game.userValue = entry;
        game.AnalyzePlay();

        string msg = stringWriter.ToString().Trim();
        msg.Should().Be("Tente um número MENOR");  
    }
    
    [Theory(DisplayName = "Deve comparar a entrada do usuário em um caso CORRETO")]
    [InlineData(50, 50)]
    public void TestProgramComparisonValuesEqual(int mockValue, int entry)
    {
        GuessNumber game = new();

        StringWriter stringWriter = new();
        Console.SetOut(stringWriter);

        game.randomValue = mockValue;
        game.userValue = entry;
        game.AnalyzePlay();

        string msg = stringWriter.ToString().Trim();
        msg.Should().Be("ACERTOU!");
    }    
}