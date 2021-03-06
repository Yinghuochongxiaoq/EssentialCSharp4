using System.Collections;

namespace AddisonWesley.Michaelis.EssentialCSharp.Chapter16.Listing16_19
{
    using Listing16_10;
    using System;
    using System.Collections.Generic;

    public class Pair<T> : IPair<T>, IEnumerable<T>
    {
        // ...

        // The iterator is expanded into the following
        // code by the compiler
        public virtual IEnumerator<T> GetEnumerator()
        {
            __ListEnumerator<T> result = new __ListEnumerator<T>(0);
            result._Pair = this;
            return result;
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return GetEnumerator();
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

        public T this[PairItem index]
        {
            get
            {
                switch (index)
                {
                    case PairItem.First:
                        return First;
                    case PairItem.Second:
                        return Second;
                    default:
                        throw new NotImplementedException(
                            string.Format(
                            "The enum {0} has not been implemented",
                            index.ToString()));
                }
            }
            set
            {
                switch (index)
                {
                    case PairItem.First:
                        First = value;
                        break;
                    case PairItem.Second:
                        Second = value;
                        break;
                    default:
                        throw new NotImplementedException(
                            string.Format(
                            "The enum {0} has not been implemented",
                            index.ToString()));
                }
            }
        }

        private sealed class __ListEnumerator<T> : IEnumerator<T>
        {
            public __ListEnumerator(int itemCount)
            {
                _ItemCount = itemCount;
            }

            public Pair<T> _Pair;
            T _Current;
            int _ItemCount;

            public void Reset()
            {
                throw new NotImplementedException();
            }

            T IEnumerator<T>.Current
            {
                get { throw new NotImplementedException(); }
            }

            public object Current
            {
                get
                {
                    return _Current;
                }
            }

            public bool MoveNext()
            {
                switch (_ItemCount)
                {
                    case 0:
                        _Current = _Pair.First;
                        _ItemCount++;
                        return true;
                    case 1:
                        _Current = _Pair.Second;
                        _ItemCount++;
                        return true;
                    default:
                        return false;
                }
            }

            public void Dispose()
            {
                throw new NotImplementedException();
            }
        }
    }
}
