using FluentAssertions;
using Xunit;

namespace OddsOrEvens.Test;

public class TestOddsOrEvens
{
    [Theory(DisplayName = "Teste de sucesso para verificar se a soma entre dois números é par ou ímpar")]
    [InlineData(2, 7, "Ímpar")]
    [InlineData(4, 6, "Par")]
    [InlineData(0, 10, "Par")]
    public void TestOddsOrEvensSuccess(int numberOne, int numberTwo, string resultExpected)
    {
        var instance = new OddsOrEvens();

        var sumNumbers = instance.SumNumbers(numberOne, numberTwo);
        var result = instance.VerifyOddsOrEvens(sumNumbers);

        result.Should().Be(resultExpected);
    }

    [Theory(DisplayName = "Teste de exceção para verificar se a soma entre dois números é par ou ímpar")]
    [InlineData(10, 11)]
    [InlineData(11, 1)]
    [InlineData(-1, 10)]
    [InlineData(8, -1)]
    public void TestOddsOrEvensException(int numberOne, int numberTwo)
    {
        var instance = new OddsOrEvens();

        var sumNumbers = () => instance.SumNumbers(numberOne, numberTwo);

        sumNumbers.Should().Throw<ArgumentOutOfRangeException>();
    }
}
