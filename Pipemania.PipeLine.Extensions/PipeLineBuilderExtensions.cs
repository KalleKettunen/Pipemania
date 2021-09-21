using System;
using Pipemania.Core;

namespace Pipemania.PipeLine.Extensions
{
    public static class PipeLineBuilderExtensions
    {
        public static IPipeLineBuilder<TResult> Map<TSource, TResult>(this IPipeLineBuilder<TSource> pipeLineBuilder, Func<TSource, TResult> func)
        {
            return pipeLineBuilder.Filter(new FunctionMapper<TSource, TResult>(func));
        }
    }
}