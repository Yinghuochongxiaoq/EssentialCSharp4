namespace AddisonWesley.Michaelis.EssentialCSharp.Chapter19.Listing19_09
{
    using System;
    using System.Threading;
    using System.Threading.Tasks;

    public class Program
    {
        static ManualResetEventSlim MainSignaledResetEvent;
        static ManualResetEventSlim DoWorkSignaledResetEvent;

        public static void DoWork()
        {
            Console.WriteLine("DoWork() started....");
            DoWorkSignaledResetEvent.Set();
            MainSignaledResetEvent.Wait();
            Console.WriteLine("DoWork() ending....");
        }

        public static void Main()
        {
            using (MainSignaledResetEvent =
                new ManualResetEventSlim())
            using (DoWorkSignaledResetEvent =
                new ManualResetEventSlim())
            {
                Console.WriteLine("Application started....");
                Console.WriteLine("Starting task....");

                Task task = Task.Factory.StartNew(DoWork);

                // Block until DoWork() has started.
                DoWorkSignaledResetEvent.Wait();
                Console.WriteLine("Thread executing...");
                MainSignaledResetEvent.Set();
                task.Wait();
                Console.WriteLine("Thread completed");
                Console.WriteLine("Application shutting down....");
            }
        }
    }

}
