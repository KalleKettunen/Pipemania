using System.Linq;
using System.Threading.Tasks;
using Pipemania.Core.Interfaces;

namespace Pipemania.Core
{
    public abstract class Mapper<TSource, TResult> : Source<TResult>, IFilter<TSource, TResult>
    {
        public async Task Receive(TSource source)
        {
            await Task.WhenAll(EndPoints.Select(async e => e.Receive(await Map(source))));
        }

        public void Ready(bool ready)
        {
            foreach (var endPoint in EndPoints)
            {
                endPoint.Ready(ready);
            }
        }

        protected abstract Task<TResult> Map(TSource source);

    }
}
