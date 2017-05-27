﻿namespace AddisonWesley.Michaelis.EssentialCSharp.Chapter09.Listing09_011
{
    public struct Latitude
    {
        public Latitude(double decimalDegrees)
        {
            _DecimalDegrees = Normalize(decimalDegrees);
        }

        public double DecimalDegrees
        {
            get { return _DecimalDegrees; }
        }
        private readonly double _DecimalDegrees;

        // ...

        public static implicit operator double(Latitude latitude)
        {
            return latitude.DecimalDegrees;
        }
        public static implicit operator Latitude(double degrees)
        {
            return new Latitude(degrees);
        }

        private static double Normalize(double decimalDegrees)
        {
            // here you would normalize the data
            return decimalDegrees;
        }
    }
}