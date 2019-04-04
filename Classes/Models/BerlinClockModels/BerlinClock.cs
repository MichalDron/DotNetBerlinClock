using System.Text;
using BerlinClock.Classes.Helpers;
using BerlinClock.Classes.Models.BerlinClockModels.Indicators;

namespace BerlinClock.Classes.Models.BerlinClockModels
{
    internal class BerlinClock : ClockBase
    {
        private readonly IIndicator _secondsIndicator;
        private readonly IIndicator _minutesIndicator;
        private readonly IIndicator _hoursIndicator;

        public BerlinClock(Time time) : base(time)
        {
            ILightToStringConverter lightToStringConverter = new LightToStringConverter();
            _secondsIndicator = new SecondsIndicator(lightToStringConverter);
            _minutesIndicator = new MinutesIndicator(lightToStringConverter);
            _hoursIndicator = new HoursIndicator(lightToStringConverter);

            SetupIndicators(time);
        }

        private void SetupIndicators(Time time)
        {
            _secondsIndicator.SetLampIndicatorState(time);
            _minutesIndicator.SetLampIndicatorState(time);
            _hoursIndicator.SetLampIndicatorState(time);
        }

        public override string GetTimeString()
        {
            var result = new StringBuilder();

            result.Append(_secondsIndicator.GetIndicatorString());
            result.AppendLine();
            result.Append(_hoursIndicator.GetIndicatorString());
            result.AppendLine();
            result.Append(_minutesIndicator.GetIndicatorString());

            return result.ToString();
        }
    }
}
