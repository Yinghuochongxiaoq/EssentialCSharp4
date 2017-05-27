namespace AddisonWesley.Michaelis.EssentialCSharp.Chapter12.Listing12_07
{
    using System;
    using Listing12_05;

    class DelegateSample
    {
        public static void BubbleSort(
            int[] items, ComparisonHandler comparisonMethod)
        {
            int i;
            int j;
            int temp;

            if (items == null)
            {
                return;
            }
            if (comparisonMethod == null)
            {
                throw new ArgumentNullException("comparisonMethod");
            }

            for (i = items.Length - 1; i >= 0; i--)
            {
                for (j = 1; j <= i; j++)
                {
                    if (comparisonMethod(items[j - 1], items[j]))
                    {
                        temp = items[j - 1];
                        items[j - 1] = items[j];
                        items[j] = temp;
                    }
                }
            }
        }

        public static bool GreaterThan(int first, int second)
        {
            return first > second;
        }
        // ...
    }
}