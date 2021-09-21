using System.Threading.Tasks;

namespace Pipemania.Core
{
    public abstract class Aggregate<TSource, TResult> : Mapper<TSource, TResult>
    {
        private TResult _aggregate;

        protected Aggregate()
        {
            _aggregate = default(TResult);
        }

        protected Aggregate(TResult initialValue)
        {
            _aggregate = initialValue;
        }
        
        protected override async Task<TResult> Map(TSource source)
        {
            _aggregate = await AggregateFunc(_aggregate, source);
            return _aggregate;
        }

        protected abstract Task<TResult> AggregateFunc(TResult aggregate, TSource current);
    }
}