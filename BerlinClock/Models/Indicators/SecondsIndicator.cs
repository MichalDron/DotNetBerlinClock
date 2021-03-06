﻿using BerlinClock.Helpers;
using BerlinClock.Models.Lamps;

namespace BerlinClock.Models.Indicators
{
    internal class SecondsIndicator : IndicatorBase
    {
        private readonly ILightToStringConverter _lightToStringConverter;
        private readonly ILamp _equalSecondIndicatorLamp = new YellowLamp();

        public SecondsIndicator(ILightToStringConverter lightToStringConverter)
        {
            _lightToStringConverter = lightToStringConverter;
        }

        public override string GetIndicatorString()
        {
            return _lightToStringConverter.Convert(_equalSecondIndicatorLamp.CurrentLight);
        }

        public override void SetLampIndicatorState(Time time)
        {
            var isSecondsEqual = time.Seconds % 2 == 0;

            if (isSecondsEqual)
            {
                this.TurnOnLamp(_equalSecondIndicatorLamp);
            }
        }
    }
}
