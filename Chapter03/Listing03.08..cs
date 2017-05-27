using System;
using System.Diagnostics;

namespace AddisonWesley.Michaelis.EssentialCSharp.Chapter03.Listing03_08
{ 
    public class Program
    { 
        public static void Main()
        {
            decimal decimalNumber = 4.2M;
            double doubleNumber1 = 0.1F * 42F;
            double doubleNumber2 = 0.1D * 42D;
            float floatNumber = 0.1F * 42F;

            Trace.Assert(decimalNumber != (decimal)doubleNumber1);
            Console.WriteLine("{0}!={1}", decimalNumber, (decimal)doubleNumber1);
            Trace.Assert((double)decimalNumber != doubleNumber1);
            Console.WriteLine("{0}!={1}", (double)decimalNumber, doubleNumber1);
            Trace.Assert((float)decimalNumber != floatNumber);
            Console.WriteLine("(float){0}M!={1}F", (float)decimalNumber, floatNumber);

            Trace.Assert(doubleNumber1 == (double)floatNumber);
            Console.WriteLine("{0}!={1}", doubleNumber1, (double)floatNumber);

            Trace.Assert(doubleNumber1 != doubleNumber2);
            Console.WriteLine("{0}!={1}", doubleNumber1, doubleNumber2);

            Trace.Assert((double)4.2F != 4.2D);
            Console.WriteLine("{0}!={1}", (double)4.2F, 4.2D);

            Trace.Assert(4.2F != 4.2D);
            Console.WriteLine("{0}F!={1}D", 4.2F, 4.2D);


            float n = 0f;
            Console.WriteLine(n / 0);

            Console.WriteLine(Math.Sqrt(-1));

            Console.WriteLine(-1f / 0);

            Console.WriteLine(3.402823E+38f * 2f);
        }
    }
}
