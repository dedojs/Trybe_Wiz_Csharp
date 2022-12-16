using FluentAssertions;
using Xunit;

namespace CharacterCounter.Test;

public class TestCharacterCounter
{    

        [Theory]
        [InlineData("Eu sou uma pessoa desenvolvedora formada na Trybe", 49)]
        [InlineData("Isso é um texto", 15)]
        public void TestCharacterCounterSuccess(string text, int resultExpected)
        {
            var instance = new CharacterCounter();
            var result = instance.Action(text);
            result.Should().Be(resultExpected);
        }

        [Theory]
        //[InlineData("")]
        [InlineData(null)]
        public void TestCharacterCounterException(string text)
        {
        var instance = new CharacterCounter();
        Action result = () => instance.Action(text);
        result.Should().Throw<NullReferenceException>().WithMessage("Valor de texto invalido");
        }
}