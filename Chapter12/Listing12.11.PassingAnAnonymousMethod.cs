namespace AddisonWesley.Michaelis.EssentialCSharp.Chapter12.Listing12_11
{
    using System;
    using Listing12_10;

    public class Program
    {
        public static void Main()
        {
            int i;
            int[] items = new int[5];
            DelegateSample.ComparisonHandler comparisonMethod;

            for (i = 0; i < items.Length; i++)
            {
                Console.Write("Enter an integer:");
                items[i] = int.Parse(Console.ReadLine());
            }

            comparisonMethod =
                delegate(int first, int second)
                {
                    return first < second;
                };

            DelegateSample.BubbleSort(items, comparisonMethod);

            for (i = 0; i < items.Length; i++)
            {
                Console.WriteLine(items[i]);
            }
        }
    }
}