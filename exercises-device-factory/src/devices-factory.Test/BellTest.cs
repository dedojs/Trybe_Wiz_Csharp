using DevicesFactory.Interfaces;
using DevicesFactory.Tools;
using FluentAssertions;
using Xunit;

namespace DevicesFactory.Test
{
    public class BellTest
    {
        [Fact]
        public void TestBellIsInstanceOfIDevice()
        {
            //Escreva um teste que verifique se,
            //classe 'Bell' foi injetada via interface,
            //checando se ele é do tipo 'IDevice'
            var newBell = new Bell();
            newBell.Should().BeAssignableTo<IDevice>();
            
        }

        [Fact]
        public void TestBellTurnOnWhenBellIsOff()
        {
            //Escreva um teste que verifique se,
            //ao chamar o método 'TurnOn()' da classe 'Bell' quando a propriedade 'IsOn' é false,
            //o valor da propriedade 'IsOn' será true
            var newBell = new Bell();
            newBell.IsOn.Should().BeFalse();
            newBell.TurnOn();
            newBell.IsOn.Should().BeTrue();
        }

        [Fact]
        public void TestBellTurnOnWhenBellIsOn()
        {
            //Escreva um teste que verifique se,
            //ao chamar o método 'TurnOn()' da classe 'Bell' quando a propriedade 'IsOn' é 'true',
            //será disparado uma exceção com a mensagem 'Bell is already on'
            var newBell = new Bell();
            newBell.IsOn.Should().BeFalse();
            newBell.TurnOn();
            Action act = () => newBell.TurnOn();
            act.Should().Throw<InvalidOperationException>();
        }

        [Fact]
        public void TestBellTurnOffWhenBellIsOn()
        {
            //Escreva um teste que verifique se,
            //ao chamar o método 'TurnOff()' da classe 'Bell' quando a propriedade 'IsOn' é true,
            //o valor da propriedade 'IsOn' será false
            var newBell = new Bell();
            newBell.IsOn = true;
            newBell.TurnOff();
            newBell.IsOn.Should().BeFalse();
        }

        [Fact]
        public void TestBellTurnOffWhenBellIsOff()
        {
            //Escreva um teste que verifique se,
            //ao chamar o método 'TurnOff()' da classe 'Bell' quando a propriedade 'IsOn' é 'false',
            //será disparado uma exceção com a mensagem 'Bell is already off'
            var newBell = new Bell();
            Action act = () => newBell.TurnOff();
            act.Should().Throw<InvalidOperationException>();
        }

        [Fact]
        public void TestBellTurnOnAndTurnOffSequentially()
        {
            //Escreva um teste que verifique se,
            //ao chamar em sequência os métodos 'TurnOn()' e 'TurnOff()' da classe 'Bell',
            //o valor da propriedade 'IsOn' será false
            var newBell = new Bell();
            newBell.TurnOn();
            newBell.TurnOff();
            newBell.IsOn.Should().BeFalse();
        }
    }
}
