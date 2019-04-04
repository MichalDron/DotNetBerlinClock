using System;
using BerlinClock.Models.Consts;
using BerlinClock.Models.Lamps;

namespace BerlinClock.Models.Indicators
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
