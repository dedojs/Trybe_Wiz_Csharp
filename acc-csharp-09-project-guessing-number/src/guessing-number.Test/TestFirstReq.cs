using Xunit;
using System.IO;
using System;
using guessing_number;
using FluentAssertions;

namespace guessing_number.Test;

[Collection("Sequential")]
public class TestFirstReq
{
    [Theory(DisplayName = "Deve exibir mensagem inicial!")]
    [InlineData(new object[] {new string[]{"---Bem-vindo ao ...---", "Para começar..."}})]
    public void TestPrintInitialMessage(string[] expected)
    {
        GuessNumber game = new ();

        var stringWriter = new StringWriter();
        Console.SetOut(stringWriter);

        game.Greet();

        var greet = stringWriter.ToString().Trim().Split('\n');
        greet.Should().Equal(expected);                                                   
    }

    [Theory(DisplayName = "Deve receber a entrada do usuário e converter para int")]
    [InlineData("0", 0)]
    public void TestReceiveUserInputAndConvert(string entry, int expected)
    {        
        GuessNumber game = new ();

        var stringReader = new StringReader(entry);
        Console.SetIn(stringReader);

        game.ChooseNumber();

        var userValue = game.userValue;
        userValue.Should().Be(expected);
    }

    [Theory(DisplayName = "Deve receber a entrada do usuário e garantir que é um numérico")]
    [InlineData(new object[] {new string[]{"10,", "10"}, 10})]
    public void TestReceiveUserInputAndVerifyType(string[] entrys, int expected)
    {
        GuessNumber game = new ();

        foreach (string entry in entrys)
        {
          var stringReader = new StringReader(entry);
          Console.SetIn(stringReader);
        }
   
        game.ChooseNumber();

        var userValue = game.userValue;
        userValue.Should().Be(expected);
    }

    [Theory(DisplayName = "Deve receber a entrada do usuário e garantir que está entre -100 e 100!")]
    [InlineData(new object[] {new string[]{"1000", "10"}, 10})]
    public void TestReceiveUserInputAndVerifyRange(string[] entrys, int expected)
    {
        GuessNumber game = new ();

        foreach (string entry in entrys)
        {
          var stringReader = new StringReader(entry);
          Console.SetIn(stringReader);
        }
   
        game.ChooseNumber();

        var userValue = game.userValue;
        userValue.Should().Be(expected);
    }    
}