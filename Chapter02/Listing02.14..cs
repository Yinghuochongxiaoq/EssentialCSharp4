namespace AddisonWesley.Michaelis.EssentialCSharp.Chapter02.Listing02_14
{ 
    class Uppercase
    { 
        static void Main()
        {
            string text;

            System.Console.Write("Enter text: ");
            text = System.Console.ReadLine();
            
            //UNEXPECTED: does not convert text to uppercase
            text.ToUpper();

            System.Console.WriteLine(text);
        }
    }
}
