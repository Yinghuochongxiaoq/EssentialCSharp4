namespace AddisonWesley.Michaelis.EssentialCSharp.Chapter13.Listing13_02
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
        private TemperatureChangeHandler _OnTemperatureChange;

        public float CurrentTemperature
        {
            get { return _CurrentTemperature; }
            set
            {
                if (value != CurrentTemperature)
                {
                    _CurrentTemperature = value;
                }
            }
        }
        private float _CurrentTemperature;
    }
}