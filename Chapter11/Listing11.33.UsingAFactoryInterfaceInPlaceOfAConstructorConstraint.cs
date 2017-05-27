namespace AddisonWesley.Michaelis.EssentialCSharp.Chapter11.Listing11_33
{
    using System.Collections.Generic;

    using System;
    public class EntityBase<TKey>
    {
        public EntityBase(TKey key)
        {
            Key = key;
        }
        public TKey Key
        {
            get { return _key; }
            set { _key = value; }
        }
        private TKey _key;
    }

    public interface IEntityFactory<T, T1>
    {
        T1 CreateNew(T key);
    }

    public class EntityDictionary<TKey, TValue, TFactory> :
          Dictionary<TKey, TValue>
        where TKey : IComparable, IFormattable
        where TValue : EntityBase<TKey>
        where TFactory : IEntityFactory<TKey, TValue>, new()
    {
        // ...

        public TValue New(TKey key)
        {
            TValue newEntity = new TFactory().CreateNew(key);
            Add(newEntity.Key, newEntity);
            return newEntity;
        }
        //...
    }
}