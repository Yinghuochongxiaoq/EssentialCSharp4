namespace AddisonWesley.Michaelis.EssentialCSharp.Chapter19.Listing19_18
{
    using System;
    using System.IO;
    using System.Net;
    using System.Linq;
    using System.Threading.Tasks;
    using System.Collections.Generic;

    public class Program
    {
        static private object ConsoleSyncObject = new object();

        public static void Main(string[] args)
        {
            Console.Clear();
            string[] urls = args;
            if (args.Length == 0)
            {
                urls = new string[]  
              {
                  "http://www.habitat-spokane.org",
                  "http://www.partnersintl.org",
                  "http://www.iassist.org ",
                  "http://www.fh.org",
                  "http://www.worldvision.org"
              };
            }

            int line = 0;
            Tuple<Task<WebResponse>, WebRequestState>[] tasksWithState =
                urls.Select(
                    url => DisplayPageSizeAsync(url, line++)).ToArray();

            while (!Task.WaitAll(tasksWithState.Select(
                taskWithState => taskWithState.Item1).ToArray(), 50))
            {
                DisplayProgress(tasksWithState);
            }
            Console.SetCursorPosition(0, line);
        }

        private static Tuple<Task<WebResponse>, WebRequestState>
            DisplayPageSizeAsync(string url, int line)
        {
            lock (ConsoleSyncObject)
            {
                Console.WriteLine(url);
            }
            WebRequest webRequest = WebRequest.Create(url);
            WebRequestState state = new WebRequestState(url, line);
            Task<WebResponse> task =
                Task<WebResponse>.Factory.FromAsync(
                    webRequest.BeginGetResponse,
                    webRequest.EndGetResponse, state)
                .ContinueWith(continueWithTask =>
                {
                    // Optional since state is available with closure
                    WebRequestState completedState =
                        (WebRequestState)continueWithTask.AsyncState;
                    Stream stream =
                        continueWithTask.Result.GetResponseStream();
                    using (StreamReader reader =
                        new StreamReader(stream))
                    {
                        int length = reader.ReadToEnd().Length;
                        DisplayPageSize(completedState, length);
                    }

                    return continueWithTask.Result;
                });

            return new Tuple<Task<WebResponse>, WebRequestState>(task, state);
        }

        private static void DisplayProgress(
            IEnumerable<Tuple<Task<WebResponse>,
                WebRequestState>> tasksWithState)
        {
            foreach (
                WebRequestState state in tasksWithState
                    .Where(task => !task.Item1.IsCompleted)
                    .Select(task => (WebRequestState)task.Item2))
            {
                DisplayProgress(state);
            }
        }

        private static void DisplayPageSize(
            WebRequestState completedState, int length)
        {
            lock (ConsoleSyncObject)
            {
                Console.SetCursorPosition(
                    completedState.ConsoleColumn,
                    completedState.ConsoleLine);
                Console.Write(FormatBytes(length));
                completedState.ConsoleColumn +=
                    length.ToString().Length;
            }
        }

        private static void DisplayProgress(WebRequestState state)
        {
            int left = state.ConsoleColumn;
            int top = state.ConsoleLine;
            lock (ConsoleSyncObject)
            {
                if (left >= Console.BufferWidth -
                    int.MaxValue.ToString().Length)
                {
                    left = state.Url.Length;

                    Console.SetCursorPosition(left, top);
                    Console.Write("".PadRight(
                        Console.BufferWidth - state.Url.Length));

                    state.ConsoleColumn = left;
                }
                else
                {
                    state.ConsoleColumn++;
                }

                Console.SetCursorPosition(left, top);
                Console.Write('.');
            }
        }

        static public string FormatBytes(long bytes)
        {
            string[] magnitudes = new string[] { "GB", "MB", "KB", "Bytes" };
            long max = (long)Math.Pow(1024, magnitudes.Length);

            return string.Format("{1:##.##} {0}",
                  magnitudes.FirstOrDefault(magnitude => bytes > (max /= 1024)) ?? "0 Bytes",
                   (decimal)bytes / (decimal)max).TrimEnd();
        }
    }

    class WebRequestState
    {
        public WebRequestState(string url, int line)
        {
            Url = url;
            ConsoleLine = line;
            ConsoleColumn = url.Length + 1;
        }
        public string Url { get; set; }
        public int ConsoleLine { get; set; }
        public int ConsoleColumn { get; set; }
    }

}






