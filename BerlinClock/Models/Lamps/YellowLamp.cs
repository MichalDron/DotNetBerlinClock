namespace BerlinClock.Models.Lamps
{
    internal class YellowLamp : LampBase
    {
        protected override Light TurnedOn => Light.Yellow;
    }
}
