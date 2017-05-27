namespace AddisonWesley.Michaelis.EssentialCSharp.Chapter19.Listing19_03
{
    using System;
    using System.Threading;
    using System.Threading.Tasks;

    class Program
    {
        readonly static object _Sync = new object();
        const int _Total = int.MaxValue;
        static long _Count = 0;

        [System.Runtime.CompilerServices.MethodImpl]
        public static void Main()
        {
            Task task = Task.Factory.StartNew(Decrement);

            // Increment
            for (int i = 0; i < _Total; i++)
            {
                bool lockTaken = false;
                try
                {
                    Monitor.Enter(_Sync, ref lockTaken);
                    _Count++;
                }
                finally
                {
                    if (lockTaken)
                    {
                        Monitor.Exit(_Sync);
                    }
                }
            }

            task.Wait();
            Console.WriteLine("Count = {0}", _Count);
        }

        static void Decrement()
        {
            for (int i = 0; i < _Total; i++)
            {
                bool lockTaken = false;
                try
                {
                    Monitor.Enter(_Sync, ref lockTaken);
                    _Count--;
                }
                finally
                {
                    if (lockTaken)
                    {
                        Monitor.Exit(_Sync);
                    }
                }
            }
        }
    }
}
