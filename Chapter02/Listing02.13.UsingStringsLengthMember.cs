namespace AddisonWesley.Michaelis.EssentialCSharp.Chapter02.Listing02_13
{ 
    class PalindromeLength
    { 
        static void Main()
        {
            string palindrome;

            System.Console.Write("Enter a palindrome: ");
            palindrome = System.Console.ReadLine();

            System.Console.WriteLine(
                "The palindrome, \"{0}\" is {1} characters.", 
                palindrome, palindrome.Length);
        }
    }
}
