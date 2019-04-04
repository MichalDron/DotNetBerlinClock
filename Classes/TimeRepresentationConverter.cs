using System;
using BerlinClock.Classes.Models;
using BerlinClock.Classes.Models.Consts;

namespace BerlinClock.Classes
{
    public class TimeRepresentationConverter : ITimeRepresentationConverter
    {
        public string ConvertTimeRepresentation(string iso8601Time)
        {
            string result;

            if (Time.TryParse(iso8601Time, out Time time))
            {
                IClock clock = new Models.BerlinClockModels.BerlinClock(time);
                result = clock.GetTimeString();
            }
            else
            {
                throw new ApplicationException(ErrorMessages.IncorrectTimeFormat);
            }

            return result;
        }
    }
}
