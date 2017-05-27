namespace AddisonWesley.Michaelis.EssentialCSharp.Chapter13.Listing13_19
{
    public class Thermostat
    {
        // Define the delegate data type
        public delegate void TemperatureChangeHandler(
            object sender, Listing13_17.Thermostat.TemperatureArgs newTemperature);

        // Declaring the delegate field to save the 
        // list of subscribers.
        private TemperatureChangeHandler OnTemperatureChange;

        public void add_OnTemperatureChange(
            TemperatureChangeHandler handler)
        {
            System.Delegate.Combine(OnTemperatureChange, handler);
        }

        public void remove_OnTemperatureChange(
            TemperatureChangeHandler handler)
        {
            System.Delegate.Remove(OnTemperatureChange, handler);
        }

        //public event TemperatureChangeHandler OnTemperatureChange
        //{
        //    add { add_OnTemperatureChange(value) }
        //    remove { remove_OnTemperatureChange(value) }
        //}
    }

}