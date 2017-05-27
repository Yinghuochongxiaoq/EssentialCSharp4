namespace AddisonWesley.Michaelis.EssentialCSharp.Chapter08.Listing08_04
{
    struct Angle
    {
        public Angle(int hours, int minutes)
            : this(hours, minutes, default(int))
        {
        }

        public Angle(int hours, int minutes, int seconds)
        {
            _Hours = hours;
            _Minutes = minutes;
            _Seconds = seconds;
        }

        public int Hours
        {
            get { return _Hours; }
        }
        private int _Hours;

        public int Minutes
        {
            get { return _Minutes; }
        }
        private int _Minutes;

        public int Seconds
        {
            get { return _Seconds; }
        }
        private int _Seconds;

        public Angle Move(int hours, int minutes, int seconds)
        {
            return new Angle(
                Hours + hours,
                Minutes + minutes,
                Seconds + seconds);
        }
    }
}
