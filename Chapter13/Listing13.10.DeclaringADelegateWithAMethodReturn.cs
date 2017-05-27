namespace AddisonWesley.Michaelis.EssentialCSharp.Chapter13.Listing13_10
{
    public enum Status
    {
        On,
        Off
    }

    // Define the delegate data type
    public delegate Status TemperatureChangeHandler(
      float newTemperature);

}