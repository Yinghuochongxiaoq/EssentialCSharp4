namespace AddisonWesley.Michaelis.EssentialCSharp.Chapter11.Listing11_28
{
    using System;

    class EntityBase<T> where T : IComparable<T>
    {
        public virtual void Method<T>(T t)
            where T : IComparable<T>
        {
            // ...
        }
    }
    class Entity<T> : EntityBase<T> 
            where T : IComparable<T>
        
    {
        public virtual void Method<T>(T t)
        //    Constraints may not be repeated on overriding members
        {
            // ...
        }
    }
}