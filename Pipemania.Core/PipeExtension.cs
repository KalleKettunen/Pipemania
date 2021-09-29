using System.Collections.Generic;
using System.Threading.Tasks;

namespace Pipemania.Core
{
    public static class PipeExtensions
    {
        public static Feeder<T> ToFeeder<T>(this IEnumerable<T> enumerable)
        {
            return new EnumerableFeeder<T>(enumerable);
        }

        public static Feeder<T> ToFeeder<T>(this Task<T> task)
        {
            return new TaskFeeder<T>(task);
        }
        
        public static ISource<TResult> Connect<TSource, TResult>(this IEnumerable<TSource> enumerable, IFilter<TSource, TResult> filter)
        {
            return new EnumerableFeeder<TSource>(enumerable).Connect(filter);
        }
        
    }
}
