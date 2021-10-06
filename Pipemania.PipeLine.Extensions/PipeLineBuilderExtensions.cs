using System;
using System.Collections.Generic;
using Pipemania.Core;

namespace Pipemania.PipeLine.Extensions
{
    public static class PipeLineBuilderExtensions
    {
        public static IBatchPipeLineBuilder<TResult> Map<TSource, TResult>(this IBatchPipeLineBuilder<TSource> pipeLineBuilder, Func<TSource, TResult> func)
        {
            return pipeLineBuilder.Filter(new FunctionMapper<TSource, TResult>(func));
        }
        
        public static IContinuousPipeLineBuilder<TResult> Map<TSource, TResult>(this IContinuousPipeLineBuilder<TSource> pipeLineBuilder, Func<TSource, TResult> func)
        {
            return pipeLineBuilder.Filter(new FunctionMapper<TSource, TResult>(func));
        }

        public static IBatchPipeLineBuilder<TSource> Flatten<TSource>(
            this IBatchPipeLineBuilder<IEnumerable<TSource>> pipeLineBuilder)
        {
            return pipeLineBuilder.Filter(new Flatten<TSource>());
        }
    }
}