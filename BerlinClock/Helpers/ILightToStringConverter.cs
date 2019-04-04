using BerlinClock.Models;

namespace BerlinClock.Helpers
{
    internal interface ILightToStringConverter
    {
        string Convert(Light light);
    }
}
