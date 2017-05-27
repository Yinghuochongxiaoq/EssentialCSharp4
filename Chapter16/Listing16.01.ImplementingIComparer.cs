namespace AddisonWesley.Michaelis.EssentialCSharp.Chapter16.Listing16_01
{
    using System.Collections.Generic;

    class Contact
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
    }

    class NameComparison : IComparer<Contact>
    {
        public int Compare(Contact x, Contact y)
        {
            int result;

            if (Contact.ReferenceEquals(x, y))
            {
                result = 0;
            }
            else
            {
                if (x == null)
                {
                    result = 1;
                }
                else if (y == null)
                {
                    result = -1;
                }
                else
                {
                    result = StringCompare(x.LastName, y.LastName);
                    if (result == 0)
                    {
                        result =
                            StringCompare(x.FirstName, y.FirstName);
                    }
                }
            }
            return result;
        }

        private static int StringCompare(string x, string y)
        {
            int result;
            if (x == null)
            {
                if (y == null)
                {
                    result = 0;
                }
                else
                {
                    result = 1;
                }
            }
            else
            {
                result = x.CompareTo(y);
            }
            return result;
        }
    }
}
