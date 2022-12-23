
using DevicesFactory.Interfaces;
using System;

namespace DevicesFactory.Tools
{
    public class Lamp : IDevice
    {
        public bool IsOn { get; set; } = false;

        public void TurnOff()
        {
            if (!IsOn)
            {
                throw new InvalidOperationException("<Dispositivo> is already off");
            }
            IsOn = false;
        }

        public void TurnOn()
        {
            if (IsOn)
            {
                throw new InvalidOperationException("<Dispositivo> is already on");
            }
            IsOn = true;
        }
    }
}
