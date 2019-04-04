namespace BerlinClock.Models.Lamps
{
    internal interface ILamp
    {
        Light CurrentLight { get; set; }

        void TurnOn();

        void TurnOff();
    }
}
