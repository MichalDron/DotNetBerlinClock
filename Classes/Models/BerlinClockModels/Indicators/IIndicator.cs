namespace BerlinClock.Classes.Models.BerlinClockModels.Indicators
{
    internal interface IIndicator
    {
        string GetIndicatorString();

        void SetLampIndicatorState(Time time);
    }
}
