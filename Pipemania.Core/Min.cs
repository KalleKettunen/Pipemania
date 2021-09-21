using System;
using System.Threading.Tasks;

namespace Pipemania.Core
{
    public class Min<T> : Aggregate<T, T> where T : IComparable<T>
    {
        protected override Task<T> AggregateFunc(T aggregate, T current)
        {
            return Task.FromResult(aggregate.CompareTo(current) == -1 ? aggregate : current);
        }
    }
}