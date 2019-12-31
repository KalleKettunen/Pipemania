using System.Collections.Generic;

namespace Pipemania.Core
{
    public static class IEnumerableExtensions
    {
        public static Feeder<T> ToFeeder<T>(this IEnumerable<T> enumerable)
        {
            return new EnumerableFeeder<T>(enumerable);
        }
    }
}
