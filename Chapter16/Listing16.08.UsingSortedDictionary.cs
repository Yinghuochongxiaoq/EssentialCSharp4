namespace AddisonWesley.Michaelis.EssentialCSharp.Chapter16.Listing16_08
{
    using System;
    using System.Collections.Generic;

    public class Program
    {
        public static void Main()
        {
            SortedDictionary<string, string> sortedDictionary =
               new SortedDictionary<string, string>();

            int index = 0;

            sortedDictionary.Add(index++.ToString(), "object");
            sortedDictionary.Add(index++.ToString(), "byte");
            sortedDictionary.Add(index++.ToString(), "uint");
            sortedDictionary.Add(index++.ToString(), "ulong");
            sortedDictionary.Add(index++.ToString(), "float");
            sortedDictionary.Add(index++.ToString(), "char");
            sortedDictionary.Add(index++.ToString(), "bool");
            sortedDictionary.Add(index++.ToString(), "ushort");
            sortedDictionary.Add(index++.ToString(), "decimal");
            sortedDictionary.Add(index++.ToString(), "int");
            sortedDictionary.Add(index++.ToString(), "sbyte");
            sortedDictionary.Add(index++.ToString(), "short");
            sortedDictionary.Add(index++.ToString(), "long");
            sortedDictionary.Add(index++.ToString(), "void");
            sortedDictionary.Add(index++.ToString(), "double");
            sortedDictionary.Add(index++.ToString(), "string");

            Console.WriteLine("Key  Value    Hashcode");
            Console.WriteLine("---  -------  ----------");
            foreach (
                KeyValuePair<string, string> i in sortedDictionary)
            {
                Console.WriteLine("{0,-5}{1,-9}{2}",
                    i.Key, i.Value, i.Key.GetHashCode());
            }
        }
    }
}