﻿namespace AddisonWesley.Michaelis.EssentialCSharp.Chapter13.Listing13_15
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
            set
            {
                if (value != CurrentTemperature)
                {
                    _CurrentTemperature = value;
                    // If there are any subscribers
                    // then notify them of changes in 
                    // temperature
                    if (OnTemperatureChange != null)
                    {
                        // Call subscribers
                        OnTemperatureChange(
                          this, new TemperatureArgs(value));
                    }
                }
            }
        }
        private float _CurrentTemperature;
    }
}