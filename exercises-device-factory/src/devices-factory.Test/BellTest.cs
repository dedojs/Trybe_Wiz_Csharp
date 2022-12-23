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
            //checando se ele � do tipo 'IDevice'
            var newBell = new Bell();
            newBell.Should().BeAssignableTo<IDevice>();
            
        }

        [Fact]
        public void TestBellTurnOnWhenBellIsOff()
        {
            //Escreva um teste que verifique se,
            //ao chamar o m�todo 'TurnOn()' da classe 'Bell' quando a propriedade 'IsOn' � false,
            //o valor da propriedade 'IsOn' ser� true
            var newBell = new Bell();
            newBell.IsOn.Should().BeFalse();
            newBell.TurnOn();
            newBell.IsOn.Should().BeTrue();
        }

        [Fact]
        public void TestBellTurnOnWhenBellIsOn()
        {
            //Escreva um teste que verifique se,
            //ao chamar o m�todo 'TurnOn()' da classe 'Bell' quando a propriedade 'IsOn' � 'true',
            //ser� disparado uma exce��o com a mensagem 'Bell is already on'
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
            //ao chamar o m�todo 'TurnOff()' da classe 'Bell' quando a propriedade 'IsOn' � true,
            //o valor da propriedade 'IsOn' ser� false
            var newBell = new Bell();
            newBell.IsOn = true;
            newBell.TurnOff();
            newBell.IsOn.Should().BeFalse();
        }

        [Fact]
        public void TestBellTurnOffWhenBellIsOff()
        {
            //Escreva um teste que verifique se,
            //ao chamar o m�todo 'TurnOff()' da classe 'Bell' quando a propriedade 'IsOn' � 'false',
            //ser� disparado uma exce��o com a mensagem 'Bell is already off'
            var newBell = new Bell();
            Action act = () => newBell.TurnOff();
            act.Should().Throw<InvalidOperationException>();
        }

        [Fact]
        public void TestBellTurnOnAndTurnOffSequentially()
        {
            //Escreva um teste que verifique se,
            //ao chamar em sequ�ncia os m�todos 'TurnOn()' e 'TurnOff()' da classe 'Bell',
            //o valor da propriedade 'IsOn' ser� false
            var newBell = new Bell();
            newBell.TurnOn();
            newBell.TurnOff();
            newBell.IsOn.Should().BeFalse();
        }
    }
}
