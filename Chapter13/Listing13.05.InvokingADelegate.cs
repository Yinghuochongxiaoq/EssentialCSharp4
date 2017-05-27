namespace AddisonWesley.Michaelis.EssentialCSharp.Chapter13.Listing13_05
{
    public class Thermostat
    {
        // Define the delegate data type
        public delegate void TemperatureChangeHandler(
            float newTemperature);

        // Define the event publisher
        public TemperatureChangeHandler OnTemperatureChange
        {
            get { return _OnTemperatureChange; }
            set { _OnTemperatureChange = value; }
        }

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
                    TemperatureChangeHandler localOnChange =
                        OnTemperatureChange;
                    if (localOnChange != null)
                    {
                        // Call subscribers
                        localOnChange(value);
                    }
                }
            }
        }

        private float _CurrentTemperature;
        private TemperatureChangeHandler _OnTemperatureChange;
    }
}