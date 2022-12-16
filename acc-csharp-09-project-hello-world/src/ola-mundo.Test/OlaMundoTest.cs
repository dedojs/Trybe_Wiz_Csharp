using ola_mundo;
using Xunit;
using System;
using FluentAssertions;

namespace ola_mundo.Test;

public class OlaMundoTest
{
    [Theory(DisplayName = "Deve exibir Olá, Mundo!")]
    [InlineData("Olá, Mundo!")]
    public void TestOlaMundo(string Expected)
    {
        string result = HelloWorld.Greet();
        result.Should().Be(Expected);
         //System.Console.WriteLine(result);                 
    }
}