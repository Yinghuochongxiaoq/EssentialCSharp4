namespace AddisonWesley.Michaelis.EssentialCSharp.Chapter12.Listing12_02
{
    class SimpleSort2
    {
        public enum SortType
        {
            Ascending,
            Descending
        }

        public static void BubbleSort(int[] items, SortType sortOrder)
        {
            int i;
            int j;
            int temp;

            if (items == null)
            {
                return;
            }

            for (i = items.Length - 1; i >= 0; i--)
            {
                for (j = 1; j <= i; j++)
                {
                    switch (sortOrder)
                    {
                        case SortType.Ascending:
                            if (items[j - 1] > items[j])
                            {
                                temp = items[j - 1];
                                items[j - 1] = items[j];
                                items[j] = temp;
                            }

                            break;

                        case SortType.Descending:
                            if (items[j - 1] < items[j])
                            {
                                temp = items[j - 1];
                                items[j - 1] = items[j];
                                items[j] = temp;
                            }

                            break;
                    }
                }
            }
        }
        // ...
    }
}