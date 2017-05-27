namespace AddisonWesley.Michaelis.EssentialCSharp.Chapter09.Listing09_24
{
    using Listing09_22;

    class DataCache
    {
        // ...
        public TemporaryFileStream FileStream
        {
            get
            {
                if (_FileStream == null)
                {
                    _FileStream = new TemporaryFileStream();
                }
                return _FileStream;
            }
        }
        private TemporaryFileStream _FileStream = null;
        // ...
    }
}