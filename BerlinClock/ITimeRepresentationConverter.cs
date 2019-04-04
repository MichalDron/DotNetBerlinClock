namespace BerlinClock
{
    public interface ITimeRepresentationConverter
    {
        string ConvertTimeRepresentation(string iso8601Time);
    }
}
