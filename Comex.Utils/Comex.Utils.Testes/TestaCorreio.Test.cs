using Comex.Utils;
using FluentAssertions;

namespace Comex.Utils.Testes
{
    public class TestaCorreios
    {
        [Theory]
        [InlineData("05028-674", '0')]
        [InlineData("15028-674", '1')]
        [InlineData("25028-674", '2')]
        [InlineData("35028-674", '3')]
        [InlineData("45028-674", '4')]
        [InlineData("55028-674", '5')]
        [InlineData("65028-674", '6')]
        [InlineData("75028-674", '7')]
        [InlineData("85028-674", '8')]
        [InlineData("95028-674", '9')]
        public void TestaCorreiosObterRegiaoPorCEPSuccess(string cepEntry, char expectedResult)
        {
            var result = Correios.ObterRegiaoPorCEP(cepEntry);
            result.Should().Be(expectedResult);
        }

        [Theory]
        [InlineData("105028-674")]
        [InlineData("1028-674")]
        [InlineData("a05028-674")]
        [InlineData("05028-674b")]
        public void TestaCorreiosObterRegiaoPorCEPFail(string cepEntry)
        {
            var result = () => Correios.ObterRegiaoPorCEP(cepEntry);
            result.Should().Throw<ArgumentException>().WithMessage("Cep informado não corresponde ao padrão aceito: xxxxx-xxx");
        }

        [Theory]
        [InlineData(null)]
        public void TestaCorreiosObterRegiaoPorCEPemptyParams(string cepEntry)
        {
            var result = () => Correios.ObterRegiaoPorCEP(cepEntry);
            result.Should().Throw<NullReferenceException>();
        }
    }
}