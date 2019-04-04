namespace BerlinClock.Models.Indicators
{
    internal interface IIndicator
    {
        string GetIndicatorString();

        void SetLampIndicatorState(Time time);
    }
}
