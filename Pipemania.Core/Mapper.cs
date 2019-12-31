using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;

namespace Pipemania.Core
{
    public abstract class Mapper<TSource, TResult> : Source<TResult>, IFilter<TSource, TResult>
    {
        public async Task Receive(TSource source)
        {
            await Task.WhenAll(EndPoints.Select(async e => e.Receive(await Map(source))));
        }

        public abstract Task<TResult> Map(TSource source);

    }
}
