using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Pipemania.Core.Interfaces;

namespace Pipemania.Core
{
    public class Flatten<TSource> : Source<TSource>, IFilter<IEnumerable<TSource>, TSource>
    {
        public async Task Receive(IEnumerable<TSource> source)
        {
            await Task.WhenAll(source.Select(async item =>
                await Task.WhenAll(
                    EndPoints.Select(async endpoint => await endpoint.Receive(item)))));
        }

        public async Task SetReady()
        {
            foreach (var endPoint in EndPoints)
            {
                await endPoint.SetReady();
            }
        }
    }
}