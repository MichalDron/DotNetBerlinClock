namespace BerlinClock.Models.Lamps
{
    internal abstract class LampBase : ILamp
    {
        protected virtual Light TurnedOn { get; set; }
        protected Light TurnedOff => Light.None;
        public Light CurrentLight { get; set; }

        protected LampBase()
        {
            CurrentLight = TurnedOff;
        }

        public void TurnOn()
        {
            CurrentLight = TurnedOn;
        }

        public void TurnOff()
        {
            CurrentLight = TurnedOff;
        }
    }
}
