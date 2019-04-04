using System.Text;
using BerlinClock.Helpers;
using BerlinClock.Models.Lamps;

namespace BerlinClock.Models.Indicators
{
    internal class HoursIndicator : IndicatorBase
    {
        private readonly ILightToStringConverter _lightToStringConverter;

        private readonly ILamp[] _5HoursIndicatorLamps = {
            new RedLamp(),
            new RedLamp(),
            new RedLamp(),
            new RedLamp()
        };

        private readonly ILamp[] _1HoursIndicatorLamps = {
            new RedLamp(),
            new RedLamp(),
            new RedLamp(),
            new RedLamp()
        };

        public HoursIndicator(ILightToStringConverter lightToStringConverter)
        {
            _lightToStringConverter = lightToStringConverter;
        }

        public override string GetIndicatorString()
        {
            var result = new StringBuilder();

            foreach (var hoursIndicatorLamp in _5HoursIndicatorLamps)
            {
                result.Append(_lightToStringConverter.Convert(hoursIndicatorLamp.CurrentLight));
            }

            result.AppendLine();

            foreach (var hoursIndicatorLamp in _1HoursIndicatorLamps)
            {
                result.Append(_lightToStringConverter.Convert(hoursIndicatorLamp.CurrentLight));
            }

            return result.ToString();
        }

        public override void SetLampIndicatorState(Time time)
        {
            var timeHour = time.Hours;
            const int fiveHours = 5;

            var fiveHourRemainder = timeHour % fiveHours;
            var fiveHourMultiplier = timeHour / fiveHours;

            TurnOn1HoursLamps(fiveHourRemainder);
            TurnOn5HoursLamps(fiveHourMultiplier);
        }

        private void TurnOn1HoursLamps(int lampsNumberToTurnOn)
        {
            TurnOnLamps(_1HoursIndicatorLamps, lampsNumberToTurnOn);
        }

        private void TurnOn5HoursLamps(int lampsNumberToTurnOn)
        {
            TurnOnLamps(_5HoursIndicatorLamps, lampsNumberToTurnOn);
        }
    }
}
