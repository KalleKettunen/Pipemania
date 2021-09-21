using System.Collections.Generic;

namespace Pipemania.Core
{
    public static class IEnumerableExtensions
    {
        public static Feeder<T> ToFeeder<T>(this IEnumerable<T> enumerable)
        {
            return new EnumerableFeeder<T>(enumerable);
        }
        
        public static ISource<TResult> Connect<TSource, TResult>(this IEnumerable<TSource> enumerable, IFilter<TSource, TResult> filter)
        {
            return new EnumerableFeeder<TSource>(enumerable).Connect(filter);
        }
        
    }
}
