namespace BerlinClock.Classes.Models.BerlinClockModels.Lamps
{
    internal class RedLamp : LampBase
    {
        protected override Light TurnedOn => Light.Red;
    }
}
