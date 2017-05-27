namespace AddisonWesley.Michaelis.EssentialCSharp.Chapter15.Listing15_06
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.IO;

    public class Program
    {
        public static void Main()
        {
            FindMonthOldFiles(Directory.GetCurrentDirectory(),"*");
        }

        static void FindMonthOldFiles(
             string rootDirectory, string searchPattern)
        {
            IEnumerable<FileInfo> files =
                from fileName in Directory.GetFiles(
                    rootDirectory, searchPattern)
                where File.GetLastWriteTime(fileName) <
                      DateTime.Now.AddMonths(-1)
                select new FileInfo(fileName);

            foreach (FileInfo file in files)
            {
                //  As simplification, current directory is
                //  assumed to be a subdirectory of
                //  rootDirectory
                string relativePath = file.FullName.Substring(
                    Environment.CurrentDirectory.Length);
                Console.WriteLine(".{0}({1})",
                                  relativePath, file.LastWriteTime);
            }
        }
    }
}
