namespace AddisonWesley.Michaelis.EssentialCSharp.Chapter04.Listing04_01
{
    class LineCount
    {
        static void Main()
        {
            int lineCount;
            string files;
            DisplayHelpText();
            files = GetFiles();
            lineCount = CountLines(files);
            DisplayLineCount(lineCount);
        }

        private static void DisplayLineCount(int lineCount)
        {
        }

        private static int CountLines(string files)
        {
            return 0;
        }

        private static string GetFiles()
        {
            return "fileName";
        }

        private static void DisplayHelpText()
        {
        }
        // ...
    }
}
