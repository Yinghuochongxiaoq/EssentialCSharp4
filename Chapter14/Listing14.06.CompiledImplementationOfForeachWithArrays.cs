﻿namespace AddisonWesley.Michaelis.EssentialCSharp.Chapter14.Listing14_06
{
    using System;

    public class Program
    {
        public static void Main()
        {
            int number;
            int[] tempArray;
            int[] array = new int[] { 1, 2, 3, 4, 5, 6 };

            tempArray = array;
            for (int counter = 0; (counter < tempArray.Length); counter++)
            {
                int item = tempArray[counter];

                Console.WriteLine(item);
            }
        }
    }
}
