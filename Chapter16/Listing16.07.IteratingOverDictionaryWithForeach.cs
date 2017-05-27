namespace AddisonWesley.Michaelis.EssentialCSharp.Chapter16.Listing16_07
{
    using System;
    using System.Collections.Generic;

    public class Program
    {
        public static void Main()
        {
            Dictionary<string, string> dictionary = new
               Dictionary<string, string>();

            int index = 0;

            dictionary.Add(index++.ToString(), "object");
            dictionary.Add(index++.ToString(), "byte");
            dictionary.Add(index++.ToString(), "uint");
            dictionary.Add(index++.ToString(), "ulong");
            dictionary.Add(index++.ToString(), "float");
            dictionary.Add(index++.ToString(), "char");
            dictionary.Add(index++.ToString(), "bool");
            dictionary.Add(index++.ToString(), "ushort");
            dictionary.Add(index++.ToString(), "decimal");
            dictionary.Add(index++.ToString(), "int");
            dictionary.Add(index++.ToString(), "sbyte");
            dictionary.Add(index++.ToString(), "short");
            dictionary.Add(index++.ToString(), "long");
            dictionary.Add(index++.ToString(), "void");
            dictionary.Add(index++.ToString(), "double");
            dictionary.Add(index++.ToString(), "string");

            Console.WriteLine("Key  Value    Hashcode");
            Console.WriteLine("---  -------  --------");
            foreach (KeyValuePair<string, string> i in dictionary)
            {
                Console.WriteLine("{0,-5}{1,-9}{2}",
                    i.Key, i.Value, i.Key.GetHashCode());
            }
        }
    }
}