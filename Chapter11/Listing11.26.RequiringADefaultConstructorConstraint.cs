﻿namespace AddisonWesley.Michaelis.EssentialCSharp.Chapter11.Listing11_26
{
    using System;
    using System.Collections.Generic;

    public class EntityBase<TKey>
    {
        public TKey Key
        {
            get { return _Key; }
            set { _Key = value; }
        }
        private TKey _Key;
    }

    public class EntityDictionary<TKey, TValue> :
        Dictionary<TKey, TValue>
        where TKey : IComparable<TKey>, IFormattable
        where TValue : EntityBase<TKey>, new()
    {
        // ...

        public TValue New(TKey key)
        {
            TValue newEntity = new TValue();
            newEntity.Key = key;
            Add(newEntity.Key, newEntity);
            return newEntity;
        }

        // ...
    }
}