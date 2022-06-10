using System.Collections.Generic;

namespace ExtensionMethods
{
    public static class MyExtensions
    {
        public static int MContains<T>(this List<T> list, T value)
        {
            EqualityComparer<T> equalityComparer = EqualityComparer<T>.Default;
            
            for (int i = 0; i < list.Count; i++)
                if (equalityComparer.Equals(list[i], value))
                    return i;
            return -1;
        }
    }
}