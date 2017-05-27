using System;
using System.Linq;
using System.Reflection;

namespace AddisonWesley.Michaelis.EssentialCSharp.Shared
{
    public class Program
    {
        public static void Main()
        {
            Console.Write("Enter the listing number to execute (e.g. For Listing 18.1 enter \"18.1\"): ");
            string input = Console.ReadLine();
            Console.WriteLine();
            Console.WriteLine("____________________________");
            Console.WriteLine();

            LaunchMain(input, null);
        }

        private static void LaunchMain(string listing ,string[] stringArguments)
        {
            bool launchedAgain = false;
            try
            {
                string[] chapterListing = listing.Split('.');
                listing = string.Empty;
                for (int index = 0; index < chapterListing.Length; index++)
                {
                    listing += chapterListing[index].PadLeft(2, '0')+".";
                }
                listing = listing.Substring(0, listing.Length - 1);
        

                Type target = Assembly.GetExecutingAssembly().GetTypes().Where(type => type.FullName.Contains(listing.Replace('.', '_'))).First();
                var method = (MethodInfo)target.GetMember("Main").First();
                object[] arguments;
                if(stringArguments == null)
                {
                    arguments = null;
                }
                else
                {
                    arguments = new object[] { stringArguments};
                }

                method.Invoke(null, arguments);
            }
            catch (TargetParameterCountException)
            {
                string[] args;
                
                Console.WriteLine();
                Console.WriteLine(
                    "Listing uses arguments for main method provided by user. Please see the listing and enter arguments or hit enter to pass in null: ");
                string userArguments = Console.ReadLine();
                Console.WriteLine();
                Console.WriteLine();

                if(userArguments != null)
                {
                    userArguments = userArguments.Trim();
                }

                if (string.IsNullOrWhiteSpace(userArguments))
                {
                    args = new string[0];
                }
                else
                {
                    args = userArguments.Split(new[]{' '});
                }
                LaunchMain(listing, args);
                launchedAgain = true;
            }
            catch (InvalidOperationException)
            {
                Console.WriteLine("----Exception----");
                Console.WriteLine(string.Format("Error, could not run the Listing '{0}', please make sure it is a valid listing and in the correct format", listing));
            }
            catch (Exception exception)
            {
                Console.WriteLine("----Exception----");
                Console.WriteLine(string.Format("Listing {0} throw an exception of type {1}.", listing, exception.GetType()));
            }

            if (!launchedAgain)
            {
                Console.WriteLine();
                Console.WriteLine("____________________________");
                Console.WriteLine("End of Listing " + listing);
                Console.Write("Press any key to exit.");
                Console.ReadKey();
            }
        }
    }
}