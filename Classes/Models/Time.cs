using System.Text.RegularExpressions;

namespace BerlinClock.Classes.Models
{
    public struct Time
    {
        private static readonly Regex TimeRegex = new Regex("^(2[0-3]|[01]?[0-9]):([0-5]?[0-9]):([0-5]?[0-9])$");
        private static readonly Regex TimeRegexMidnight = new Regex("^(24):(0?0):(0?0)$");

        public int Seconds;
        public int Minutes;
        public int Hours;

        public static bool TryParse(string s, out Time result)
        {
            result = new Time();

            if (string.IsNullOrWhiteSpace(s))
            {
                return false;
            }

            Match match = TimeRegex.Match(s);

            if (!match.Success)
            {
                match = TimeRegexMidnight.Match(s);

                if (!match.Success)
                {
                    return false;
                }
            }

            result.Hours = int.Parse(match.Groups[1].Value);
            result.Minutes = int.Parse(match.Groups[2].Value);
            result.Seconds = int.Parse(match.Groups[3].Value);

            return true;
        }
    }
}
