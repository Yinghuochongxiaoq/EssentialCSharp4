namespace AddisonWesley.Michaelis.EssentialCSharp.Chapter16.Listing16_13
{
    using System;
    using System.Collections.Generic;

    public class Program
    {
        public static void Main()
        {
            CSharpPrimitiveTypes primitives =
                new CSharpPrimitiveTypes();

            foreach (string primitive in primitives)
            {
                Console.WriteLine(primitive);
            }
        }
    }
    
    public class CSharpPrimitiveTypes : IEnumerable<string>
    {
        public IEnumerator<string> GetEnumerator()
        {
            yield return "object";
            yield return "byte";
            yield return "uint";
            yield return "ulong";
            yield return "float";
            yield return "char";
            yield return "bool";
            yield return "ushort";
            yield return "decimal";
            yield return "int";
            yield return "sbyte";
            yield return "short";
            yield return "long";
            yield return "void";
            yield return "double";
            yield return "string";
        }

        // IEnumerator also required because IEnumerator<T>
        // derives from it.
        System.Collections.IEnumerator
            System.Collections.IEnumerable.GetEnumerator()
        {
            // Invoke IEnumerator<string> GetEnumerator() above
            return GetEnumerator();
        }
    }
}
