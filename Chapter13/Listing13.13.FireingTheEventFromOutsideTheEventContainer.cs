namespace AddisonWesley.Michaelis.EssentialCSharp.Chapter13.Listing13_13
{
    using Listing13_01;
    using Listing13_09;

    public class Program
    {
        public static void Main()
        {
            Thermostat thermostat = new Thermostat();
            Heater heater = new Heater(60);
            Cooler cooler = new Cooler(80);
            string temperature;

            // Note: Use new Thermostat.TemperatureChangeHandler(
            //       cooler.OnTemperatureChanged) if C# 1.0.
            thermostat.OnTemperatureChange +=
                heater.OnTemperatureChanged;

            thermostat.OnTemperatureChange +=
                cooler.OnTemperatureChanged;

            //thermostat.OnTemperatureChange(42); //doesn't compile
        }
    }
}