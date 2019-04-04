using System.Text;
using BerlinClock.Helpers;
using BerlinClock.Models.Lamps;

namespace BerlinClock.Models.Indicators
{
    internal class MinutesIndicator : IndicatorBase
    {
        private readonly ILightToStringConverter _lightToStringConverter;

        private readonly ILamp[] _5MinutesIndicatorLamps = {
            new YellowLamp(),
            new YellowLamp(),
            new RedLamp(),
            new YellowLamp(),
            new YellowLamp(),
            new RedLamp(),
            new YellowLamp(),
            new YellowLamp(),
            new RedLamp(),
            new YellowLamp(),
            new YellowLamp()
        };

        private readonly ILamp[] _1MinutesIndicatorLamps = {
            new YellowLamp(),
            new YellowLamp(),
            new YellowLamp(),
            new YellowLamp()
        };

        public MinutesIndicator(ILightToStringConverter lightToStringConverter)
        {
            _lightToStringConverter = lightToStringConverter;
        }

        public override string GetIndicatorString()
        {
            var result = new StringBuilder();

            foreach (var minutesIndicatorLamp in _5MinutesIndicatorLamps)
            {
                result.Append(_lightToStringConverter.Convert(minutesIndicatorLamp.CurrentLight));
            }

            result.AppendLine();

            foreach (var minutesIndicatorLamp in _1MinutesIndicatorLamps)
            {
                result.Append(_lightToStringConverter.Convert(minutesIndicatorLamp.CurrentLight));
            }

            return result.ToString();
        }

        public override void SetLampIndicatorState(Time time)
        {
            var timeMinute = time.Minutes;
            const int fiveMinutes = 5;

            var fiveMinuteRemainder = timeMinute % fiveMinutes;
            var fiveMinuteMultiplier = timeMinute / fiveMinutes;

            TurnOn1MinutesLamps(fiveMinuteRemainder);
            TurnOn5MinutesLamps(fiveMinuteMultiplier);
        }

        private void TurnOn1MinutesLamps(int lampsNumberToTurnOn)
        {
            TurnOnLamps(_1MinutesIndicatorLamps, lampsNumberToTurnOn);
        }

        private void TurnOn5MinutesLamps(int lampsNumberToTurnOn)
        {
            TurnOnLamps(_5MinutesIndicatorLamps, lampsNumberToTurnOn);
        }
    }
}
