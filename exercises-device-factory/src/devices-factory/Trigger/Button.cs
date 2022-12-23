using DevicesFactory.Interfaces;

namespace DevicesFactory.Trigger
{
    public class Button
    {
        public readonly IDevice _device;

        public Button(IDevice device)
        {
            _device = device;
        }

        public void Trigger()
        {
            if (_device.IsOn == false)
                _device.TurnOn();

            else
                _device.TurnOff();
        }

    }
}
