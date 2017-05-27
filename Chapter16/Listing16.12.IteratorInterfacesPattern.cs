namespace AddisonWesley.Michaelis.EssentialCSharp.Chapter16.Listing16_12
{
    using System.Collections;
    using System.Collections.Generic;

    public class BinaryTree<T> :
        IEnumerable<T>
    {
        public BinaryTree(T value)
        {
            Value = value;
        }

        #region IEnumerable<T>
        public IEnumerator<T> GetEnumerator()
        {
            //...
            return new List<T>.Enumerator();//This will be implimented in 16.16
        }
        IEnumerator IEnumerable.GetEnumerator()
        {
            //...
            return GetEnumerator();//This will be implimented in 16.16
        }

        #endregion IEnumerable<T>

        public T Value
        {
            get { return _value; }
            set { _value = value; }
        }
        private T _value;

        public Pair<BinaryTree<T>> SubItems
        {
            get { return _subItems; }
            set { _subItems = value; }
        }
        private Pair<BinaryTree<T>> _subItems;
    }

    public struct Pair<T>
    {
        public Pair(T first, T second)
        {
            _first = first;
            _second = second;
        }
        public T First
        {
            get { return _first; }
            private set { _first = value; }
        }
        private T _first;
        public T Second
        {
            get { return _second; }
            private set { _second = value; }
        }
        private T _second;
    }
}
