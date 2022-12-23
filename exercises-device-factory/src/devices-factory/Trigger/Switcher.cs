using DevicesFactory.Interfaces;
using System;

namespace DevicesFactory.Trigger
{
    public class Switcher
    {
        public IDevice _device;
        public IDevice Device
        {
            get
            {
                if (_device == null)
                {
                    throw new ArgumentException("Objeto não inicializado");
                }
                return _device;
            }
            set
            {
                _device = value;
            }

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
