namespace AddisonWesley.Michaelis.EssentialCSharp.Chapter08.Listing08_07
{
    using System;
    public class Program
    {
        public static void Main()
        {
            // ...

            Angle angle = new Angle(25, 58, 23);
            object objectAngle = angle;  // Box
            Console.Write(((Angle)objectAngle).Hours);

            // Unbox and discard
            ((Angle)objectAngle).MoveTo(26, 58, 23);
            Console.Write(", " + ((Angle)objectAngle).Hours);

            // Box, modify, and discard
            ((IAngle)angle).MoveTo(26, 58, 23);
            Console.Write(", " + ((Angle)angle).Hours);

            // Modify heap directly
            ((IAngle)objectAngle).MoveTo(26, 58, 23);
            Console.WriteLine(", " + ((Angle)objectAngle).Hours);

            // ...
        }
    }

    interface IAngle
    {
        void MoveTo(int hours, int minutes, int seconds);
    }
    struct Angle : IAngle
    {
        // ...

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

        public void MoveTo(int hours, int minutes, int seconds)
        {
            _Hours = hours;
            _Minutes = minutes;
            _Seconds = seconds;
        }
    }
}
