namespace BerlinClock.Models.Lamps
{
    internal class RedLamp : LampBase
    {
        protected override Light TurnedOn => Light.Red;
    }
}
