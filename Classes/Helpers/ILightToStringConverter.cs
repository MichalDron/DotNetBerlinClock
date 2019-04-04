using BerlinClock.Classes.Models.BerlinClockModels;
using BerlinClock.Classes.Models.BerlinClockModels.Lamps;

namespace BerlinClock.Classes.Helpers
{
    internal interface ILightToStringConverter
    {
        string Convert(Light light);
    }
}
