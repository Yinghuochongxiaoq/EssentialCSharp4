﻿namespace AddisonWesley.Michaelis.EssentialCSharp.Chapter13.Listing13_14
{
    public class Thermostat
    {
        public class TemperatureArgs : System.EventArgs
        {
            public TemperatureArgs(float newTemperature)
            {
                NewTemperature = newTemperature;
            }

            public float NewTemperature
            {
                get { return _newTemperature; }
                set { _newTemperature = value; }
            }
            private float _newTemperature;
        }

        // Define the delegate data type
        public delegate void TemperatureChangeHandler(
            object sender, TemperatureArgs newTemperature);

        // Define the event publisher
        public event TemperatureChangeHandler OnTemperatureChange =
            delegate { };

        public float CurrentTemperature
        {
            get { return _CurrentTemperature; }
            set { _CurrentTemperature = value; }
        }
        private float _CurrentTemperature;
    }
}