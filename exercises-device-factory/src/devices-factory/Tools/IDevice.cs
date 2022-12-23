namespace DevicesFactory.Interfaces
{
    public interface IDevice
    {
        public bool IsOn { get; set; }
        public void TurnOn();
        public void TurnOff();
    }
}