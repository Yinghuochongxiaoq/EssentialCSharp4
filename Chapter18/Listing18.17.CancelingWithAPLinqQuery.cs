namespace AddisonWesley.Michaelis.EssentialCSharp.Shared.Listing18_17
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Threading;
    using System.Threading.Tasks;

    public class Program
    {

        public static List<string> ParallelEncrypt(
            List<string> data,
            CancellationToken cancellationToken)
        {
            return data.AsParallel().WithCancellation(
                cancellationToken).Select( 
                (item) => Encrypt(item)).ToList();
        }

        private static string Encrypt(string fileName)
        {
            Console.WriteLine("Encrypting " + fileName);
            Thread.Sleep(2000);
            Console.WriteLine("Done with "+fileName);
            return fileName;
        }

        public static void Main()
        {
            string stars = "*".PadRight(Console.WindowWidth, '*');

            List<string> data = Utility.GetData(1000000).ToList();

            CancellationTokenSource cts =
                new CancellationTokenSource();

            Console.WriteLine("Push ENTER to exit.");

            Task task = Task.Factory.StartNew(() =>
            {
                data = ParallelEncrypt(data, cts.Token);
            }, cts.Token);

            // Wait for the user's input
            Console.Read();

            cts.Cancel();
            Console.Write(stars);
            try { task.Wait(); }
            catch (AggregateException) { }
        }
    }
}
