﻿namespace AddisonWesley.Michaelis.EssentialCSharp.Chapter19.Listing19_22
{
    using System;
    using System.Threading;
    using System.ComponentModel;

    public class Program
    {
        static void Complete(
            object sender, RunWorkerCompletedEventArgs eventArgs)
        {
            Console.WriteLine();
            if (eventArgs.Cancelled)
            {
                Console.WriteLine("Cancelled");
            }
            else if (eventArgs.Error != null)
            {
                // IMPORTANT: check error to retrieve any 
                // exceptions.
                Console.WriteLine(
                    "ERROR: {0}", eventArgs.Error.Message);
            }
            else
            {
                Console.WriteLine("Finished");
            }
            resetEvent.Set();
        }

        private static ManualResetEvent resetEvent = new ManualResetEvent(false);//for example purposes
    }
}