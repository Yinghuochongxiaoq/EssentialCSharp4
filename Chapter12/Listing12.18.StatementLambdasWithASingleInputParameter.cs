namespace AddisonWesley.Michaelis.EssentialCSharp.Chapter12.Listing12_18
{
    using System.Collections.Generic;
    using System.Diagnostics;
    using System.Linq;

    public class Program
    {
        public static void Main()
        {
            IEnumerable<Process> processes = Process.GetProcesses().Where(
                process => { return process.WorkingSet64 >  (2 ^ 30); });
        }
    }
}