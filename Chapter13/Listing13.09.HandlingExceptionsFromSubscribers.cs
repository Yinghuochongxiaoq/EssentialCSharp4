namespace AddisonWesley.Michaelis.EssentialCSharp.Chapter13.Listing13_09
{
    using System;

    public class Thermostat
    {
        // Define the delegate data type
        public delegate void TemperatureChangeHandler(
            float newTemperature);

        // Define the event publisher
        public event TemperatureChangeHandler OnTemperatureChange;

        public float CurrentTemperature
        {
            get { return _CurrentTemperature; }
            set
            {
                if (value != CurrentTemperature)
                {
                    _CurrentTemperature = value;
                    if (OnTemperatureChange != null)
                    {
                        foreach (
                            TemperatureChangeHandler handler in
                            OnTemperatureChange.GetInvocationList())
                        {
                            try
                            {
                                handler(value);
                            }
                            catch (Exception exception)
                            {
                                Console.WriteLine(exception.Message);
                            }
                        }
                    }
                }
            }
        }
        private float _CurrentTemperature;
    }
}