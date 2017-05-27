namespace AddisonWesley.Michaelis.EssentialCSharp.Chapter12.Listing12_14
{
    using System;

    public class Program
    {
        public static void Main()
        {
            // Contravariance
            Action<object> broadAction =
              delegate(object data)
              {
                  Console.WriteLine(data);
              };
            Action<string> narrowAction = broadAction;

            // Contravariance
            Func<string> narrowFunction =
              delegate()
              {
                  return Console.ReadLine();
              };
            Func<object> broadFunction = narrowFunction;

            // Contravariance & Covariance Combined
            Func<object, string> func1 =
              delegate(object data)
              {
                  return data.ToString();
              };
            Func<string, object> func2 = func1;
        }
    }
}