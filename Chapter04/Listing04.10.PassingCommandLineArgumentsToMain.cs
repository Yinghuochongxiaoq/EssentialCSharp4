namespace AddisonWesley.Michaelis.EssentialCSharp.Chapter04.Listing04_10
{
    using System;
    using System.IO;
    using System.Net;

    public class Program
    {
        public static int Main(string[] args)
        {
            int result;
            string targetFileName = ParseCommandLineArgs(args);

            switch (args.Length)
            {
                case 0:
                    // No URL specified, so display error.
                    Console.WriteLine(
                        "ERROR:  You must specify the "
                        + "URL to be downloaded");
                    break;
                case 1:
                    // No target filename was specified.
                    targetFileName = Path.GetFileName(args[0]);
                    break;
                case 2:
                    targetFileName = args[1];
                    break;
            }

            if (targetFileName != null)
            {
                WebClient webClient = new WebClient();
                webClient.DownloadFile(args[0], targetFileName);
                result = 0;
            }
            else
            {
                Console.WriteLine(
                    "Downloader.exe <URL> <TargetFileName>");
                result = 1;
            }
            return result;
        }

        private static string ParseCommandLineArgs(string[] args)
        {
            string targetFileName = null;
            switch (args.Length)
            {
                case 0:
                    // No URL specified, so display error.
                    Console.WriteLine(
                        "ERROR:  You must specify the "
                        + "URL to be downloaded");
                    break;
                case 1:
                    // No target filename was specified.
                    targetFileName = Path.GetFileName(args[0]);
                    break;
                case 2:
                    targetFileName = args[1];
                    break;
            }
            return targetFileName;
        }
    }
}