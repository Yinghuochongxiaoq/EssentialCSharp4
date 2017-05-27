namespace AddisonWesley.Michaelis.EssentialCSharp.Chapter11.Listing11_01
{
    public class Stack
    {
        public virtual object Pop() { return new object(); }//would return that last object added and remove it from the list
        public virtual void Push(object obj) {}
        // ...
    }

}