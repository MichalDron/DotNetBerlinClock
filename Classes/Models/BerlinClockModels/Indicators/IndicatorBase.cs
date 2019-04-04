using System;
using BerlinClock.Classes.Models.BerlinClockModels.Lamps;
using BerlinClock.Classes.Models.Consts;

namespace BerlinClock.Classes.Models.BerlinClockModels.Indicators
{
    internal abstract class IndicatorBase : IIndicator
    {
        protected void TurnOnLamps(ILamp[] lamps, int lampsNumberToTurnOn)
        {
            if (lampsNumberToTurnOn > lamps.Length)
            {
                throw new ApplicationException(ErrorMessages.IncorrectLampsNumber);
            }

            for (int i = 0; i < lampsNumberToTurnOn; i++)
            {
                TurnOnLamp(lamps[i]);
            }
        }

        protected void TurnOnLamp(ILamp lamp)
        {
            lamp.TurnOn();
        }

        public abstract string GetIndicatorString();

        public abstract void SetLampIndicatorState(Time time);
    }
}
