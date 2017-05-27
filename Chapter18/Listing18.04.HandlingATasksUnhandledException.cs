using System;
using System.Collections.Generic;
using System.IO;
namespace AddisonWesley.Michaelis.EssentialCSharp.Shared.Listing18_04
{
    using System;
    using System.Threading.Tasks;

    public class Program
    {
        public static void Main()
        {
            Task task = Task.Factory.StartNew(() =>
            {
                throw new ApplicationException();
            });

            try
            {
                task.Wait();
            }
            catch (AggregateException exception)
            {
                foreach (Exception item in
                    exception.InnerExceptions)
                {
                    Console.WriteLine(
                        "ERROR: {0}", item.Message);
                }
            }
        }
    }
}
            