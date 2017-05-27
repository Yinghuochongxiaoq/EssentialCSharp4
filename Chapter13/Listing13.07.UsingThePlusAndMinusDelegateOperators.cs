﻿namespace AddisonWesley.Michaelis.EssentialCSharp.Chapter13.Listing13_07
{
    using System;
    using Listing13_01;
    using Listing13_05;

    public class Program
    {
        public static void Main()
        {
            Thermostat thermostat = new Thermostat();
            Heater heater = new Heater(60);
            Cooler cooler = new Cooler(80);

            Thermostat.TemperatureChangeHandler delegate1;
            Thermostat.TemperatureChangeHandler delegate2;
            Thermostat.TemperatureChangeHandler delegate3;

            // Note: Use new Thermostat.TemperatureChangeHandler(
            //       cooler.OnTemperatureChanged) for C# 1.0 syntax.
            delegate1 = heater.OnTemperatureChanged;
            delegate2 = cooler.OnTemperatureChanged;

            Console.WriteLine("Combine delegates using + operator:");
            delegate3 = delegate1 + delegate2;
            delegate3(60);

            Console.WriteLine("Uncombine delegates using - operator:");
            delegate3 = delegate3 - delegate2;
            delegate3(60);
        }
    }
}