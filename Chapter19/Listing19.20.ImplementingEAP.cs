using AddisonWesley.Michaelis.EssentialCSharp.Shared;

namespace AddisonWesley.Michaelis.EssentialCSharp.Chapter19.Listing19_20
{
    using System;
    using System.ComponentModel;
    using System.Threading;
    using System.Threading.Tasks;
    using System.Threading;

    public class Program
    {
        public static void Main()
        {
            ManualResetEventSlim resetEvent =
                new ManualResetEventSlim();
            PiCalculation piCalculation = new PiCalculation();
            piCalculation.CalculateCompleted +=
                (object sender,
                    PiCalculation.CalculateCompletedEventArgs eventArgs) =>
                {
                    Console.WriteLine(
                        Environment.NewLine + eventArgs.Result);
                    resetEvent.Set();
                };
            piCalculation.CalculateAsync(500, null);

            while (!resetEvent.Wait(100))
            {
                Console.Write(".");
            }
        }
    }

    partial class PiCalculation
    {
        public void CalculateAsync(
            int digits)
        {
            CalculateAsync(digits, null);
        }
        public void CalculateAsync(
            int digits, object userState)
        {
            CalculateAsync(
                digits, default(CancellationToken), userState);
        }
        public void CalculateAsync<TState>(
            int digits,
            CancellationToken cancelToken,
            TState userState)
        {
            Task<string>.Factory.StartNew(
                () => PiCalculator.Calculate(digits), cancelToken)
                .ContinueWith<string>(
                    continueTask =>
                    {
                        CalculateCompleted(typeof(PiCalculator),
                            new CalculateCompletedEventArgs(
                                continueTask.Result,
                                continueTask.Exception,
                                cancelToken.IsCancellationRequested,
                                userState));
                        return continueTask.Result;
                    });
        }
        public event
            EventHandler<CalculateCompletedEventArgs>
                CalculateCompleted = delegate { };


        public class CalculateCompletedEventArgs
            : AsyncCompletedEventArgs
        {
            public CalculateCompletedEventArgs(
                string value,
                Exception error,
                bool cancelled,
                object userState)
                : base(
                    error, cancelled, userState)
            {
                Result = value;
            }
            public string Result { get; private set; }
        }
    }
}







