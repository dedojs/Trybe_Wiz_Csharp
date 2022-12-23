using DevicesFactory.Interfaces;
using DevicesFactory.Tools;
using FluentAssertions;
using Xunit;

namespace DevicesFactory.Test
{
    public class LampTest
    {
        [Fact]
        public void TestLampIsInstanceOfIDevice()
        {
            //Escreva um teste que verifique se,
            //classe 'Lamp' foi injetada via interface,
            //checando se ele é do tipo 'IDevice'
            var lamp = new Lamp();
            lamp.Should().BeAssignableTo<IDevice>();
            
        }

        [Fact]
        public void TestLampTurnOnWhenLampIsOff()
        {
            //Escreva um teste que verifique se,
            //ao chamar o método 'TurnOn()' da classe 'Lamp' quando a propriedade 'IsOn' é 'false',
            //o valor da propriedade 'IsOn' será true
            var lamp = new Lamp();
            lamp.IsOn.Should().BeFalse();
            lamp.TurnOn();
            lamp.IsOn.Should().BeTrue();
        }

        [Fact]
        public void TestLampTurnOnWhenLampIsOn()
        {
            //Escreva um teste que verifique se,
            //ao chamar o método 'TurnOn()' da classe 'Lamp' quando a propriedade 'IsOn' é 'true',
            //será disparado uma exceção com a mensagem 'Lamp is already on'
            var lamp = new Lamp();
            lamp.IsOn.Should().BeFalse();
            lamp.TurnOn();
            lamp.IsOn.Should().BeTrue();
            Action action = () => lamp.TurnOn();
            action.Should().Throw<InvalidOperationException>();
        }

        [Fact]
        public void TestLampTurnOffWhenLampIsOn()
        {
            //Escreva um teste que verifique se,
            //ao chamar o método 'TurnOff()' da classe 'Lamp' quando a propriedade 'IsOn' é 'true',
            //o valor da propriedade 'IsOn' será false
            var lamp = new Lamp();
            lamp.IsOn = true;
            lamp.TurnOff();
            lamp.IsOn.Should().BeFalse();
        }

        [Fact]
        public void TestLampTurnOffWhenLampIsOff()
        {
            //Escreva um teste que verifique se,
            //ao chamar o método 'TurnOff()' da classe 'Lamp' quando a propriedade 'IsOn' é 'false',
            //será disparado uma exceção com a mensagem 'Lamp is already off'
            var lamp = new Lamp();
            Action action = () => lamp.TurnOff();
            action.Should().Throw<InvalidOperationException>();
        }

        [Fact]
        public void TestLampTurnOnAndTurnOffSequentially()
        {
            //Escreva um teste que verifique se,
            //ao chamar em sequência os métodos 'TurnOn()' e 'TurnOff()' da classe 'Lamp',
            //o valor da propriedade 'IsOn' será 'false'
            var lamp = new Lamp();
            lamp.TurnOn();
            lamp.TurnOff();
            lamp.IsOn.Should().BeFalse();
        }
    }
}
