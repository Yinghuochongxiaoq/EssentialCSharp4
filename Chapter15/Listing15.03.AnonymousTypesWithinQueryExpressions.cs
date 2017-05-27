namespace AddisonWesley.Michaelis.EssentialCSharp.Chapter15.Listing15_03
{
    using System;
    using System.Collections.Generic;
    using System.IO;
    using System.Linq;

    public class Program
    {
        public static void Main()
        {
            List1(Directory.GetCurrentDirectory(),"*");
        }

        static void List1(string rootDirectory, string searchPattern)
        {
            IEnumerable<FileInfo> files =
                from fileName in Directory.GetFiles(
                    rootDirectory, searchPattern)
                select new FileInfo(fileName);

            foreach (FileInfo file in files)
            {
                Console.WriteLine(".{0} ({1})",
                    file.Name, file.LastWriteTime);
            }
        }
    }
}