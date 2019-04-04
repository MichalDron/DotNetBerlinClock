using System;
using BerlinClock.Models;
using BerlinClock.Models.Consts;

namespace BerlinClock
{
    public class TimeRepresentationConverter : ITimeRepresentationConverter
    {
        public string ConvertTimeRepresentation(string iso8601Time)
        {
            string result;

            if (Time.TryParse(iso8601Time, out Time time))
            {
                IClock clock = new Models.BerlinClock(time);
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
