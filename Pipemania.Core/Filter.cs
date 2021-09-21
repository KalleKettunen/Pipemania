using System.Linq;
using System.Threading.Tasks;

namespace Pipemania.Core
{
    public abstract class Filter<TSource> : Source<TSource>, IFilter<TSource, TSource>
    {
        public async Task Receive(TSource source)
        {
            if (FilterFunc(source))
                await Task.WhenAll(EndPoints.Select(e => e.Receive(source)));
        }

        protected abstract bool FilterFunc(TSource source);
    }
}