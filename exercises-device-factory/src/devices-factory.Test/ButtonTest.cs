using DevicesFactory.Tools;
using DevicesFactory.Trigger;
using FluentAssertions;
using Xunit;

namespace DevicesFactory.Test
{
    public class ButtonTest
    {
        [Theory]
        [InlineData(1, true)]
        [InlineData(2, false)]
        [InlineData(13, true)]
        [InlineData(20, false)]
        public void TestButtonCanInstantiateWithDifferentDevices(int timesTriggered, bool expectedValue)
        {
            //timestriggered = número de vezes que o método 'Trigger' de 'Button' é acionado
            //expectedValue = o valor final da propriedade 'IsOn' dos dispositivos acionados
            var lamp = new Lamp();
            var button = new Button(lamp);
            for (int i = 0; i < timesTriggered; i++)
            {
                button.Trigger();
            }
            button._device.IsOn.Should().Be(expectedValue);

        }
    }
}
