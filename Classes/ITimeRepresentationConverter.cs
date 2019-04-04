namespace BerlinClock.Classes
{
    public interface ITimeRepresentationConverter
    {
        string ConvertTimeRepresentation(string iso8601Time);
    }
}
