namespace BerlinClock.Classes.Models.BerlinClockModels.Lamps
{
    internal interface ILamp
    {
        Light CurrentLight { get; set; }

        void TurnOn();

        void TurnOff();
    }
}
