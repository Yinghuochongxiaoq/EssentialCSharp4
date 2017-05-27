namespace AddisonWesley.Michaelis.EssentialCSharp.Chapter08.Listing08_01
{
    struct Angle
    {
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

    // Declaring a class - a reference type
    // (declaring it as a struct would create a value type
    // larger than 16 bytes.)
    class Coordinate
    {
        public Angle Longitude
        {
            get { return _Longitude; }
            set { _Longitude = value; }
        }
        private Angle _Longitude;

        public Angle Latitude
        {
            get { return _Latitude; }
            set { _Latitude = value; }
        }
        private Angle _Latitude;
    }
}