namespace AddisonWesley.Michaelis.EssentialCSharp.Chapter08.Listing08_12
{
    using System;
    using Listing08_11;

    public class Program
    {
        public static void Main()
        {
            ConnectionState1[] states =
                (ConnectionState1[])(Array)new ConnectionState2[42];

            System.Diagnostics.Trace.WriteLine(string.Format(
                "The Connection is currently {0}.",
                ConnectionState.Disconnecting));//note that the Trace.WriteLine outputs to the Output window, not the Console

        }
    }

    enum ConnectionState1
    {
        Disconnected,
        Connecting,
        Connected,
        Disconnecting
    }
    enum ConnectionState2
    {
        Disconnected,
        Connecting,
        Connected,
        Disconnecting
    }
}
