namespace BerlinClock.Classes.Models
{
    internal abstract class ClockBase : IClock
    {
        protected Time Time;

        protected ClockBase(Time time)
        {
            Time = time;
        }

        public override string ToString()
        {
            return this.GetTimeString();
        }

        public abstract string GetTimeString();
    }
}
