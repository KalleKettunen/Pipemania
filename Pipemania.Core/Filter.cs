using System.Linq;
using System.Threading.Tasks;
using Pipemania.Core.Interfaces;

namespace Pipemania.Core
{
    public abstract class Filter<TSource> : Source<TSource>, IFilter<TSource, TSource>
    {
        public async Task Receive(TSource source)
        {
            if (FilterFunc(source))
                await Task.WhenAll(EndPoints.Select(e => e.Receive(source)));
        }

        public void Ready(bool ready)
        {
            foreach (var endPoint in EndPoints)
            {
                endPoint.Ready(true);
            }
        }

        protected abstract bool FilterFunc(TSource source);
    }
}